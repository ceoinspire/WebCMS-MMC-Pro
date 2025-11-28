using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace MMC_Pro_Edition.Repository
{
    public static class InputValidator
    {
        public static bool IsPromptSafe(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // 1. Limit length
            if (input.Length > 2000)
                return false;

            // 2. Block HTML tags
            if (Regex.IsMatch(input, "<.*?>", RegexOptions.IgnoreCase))
                return false;

            // 3. Block script blocks
            if (Regex.IsMatch(input, "(<script.*?>|</script>)", RegexOptions.IgnoreCase))
                return false;

            // 4. Block SQL injection patterns
            string[] sqlKeywords = { "DROP ", "ALTER ", "INSERT ", "UPDATE ", "DELETE ", "SELECT ", "--", ";" };
            foreach (var word in sqlKeywords)
            {
                if (input.ToUpper().Contains(word))
                    return false;
            }

            // 5. Block code-like patterns
            string[] codePatterns =
            {
            "using ", "namespace ", "public class", "console.log", "function(", "eval(",
            "import ", "def ", "class ", "var ", "let ", "=>"
        };

            foreach (var pattern in codePatterns)
            {
                if (input.ToLower().Contains(pattern))
                    return false;
            }

            // 6. Block command injection
            if (Regex.IsMatch(input, @"(\bchmod\b|\bshutdown\b|\bexec\b|\bpassthru\b|\bpowershell\b)", RegexOptions.IgnoreCase))
                return false;

            // 7. Block long Base64 blocks
            if (Regex.IsMatch(input, @"[A-Za-z0-9+/]{150,}={0,2}"))
                return false;

            // If no rules matched → safe
            return true;
        }
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }

        public static class LoginRateLimiter
        {
            // IP -> (Attempts, LastAttempt)
            private static readonly ConcurrentDictionary<string, (int Attempts, DateTime LastAttempt)> _attempts
                = new ConcurrentDictionary<string, (int, DateTime)>();

            private const int LIMIT = 5;
            private static readonly TimeSpan WINDOW = TimeSpan.FromMinutes(1);

            public static bool IsBlocked(string ip)
            {
                if (_attempts.TryGetValue(ip, out var entry))
                {
                    // if window not expired and attempts >= limit → block
                    if (entry.Attempts >= LIMIT &&
                        DateTime.UtcNow - entry.LastAttempt < WINDOW)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static void RegisterFailedAttempt(string ip)
            {
                _attempts.AddOrUpdate(ip,
                    addValue: (1, DateTime.UtcNow),
                    updateValueFactory: (key, old) =>
                        (old.Attempts + 1, DateTime.UtcNow));
            }

            public static void ResetAttempts(string ip)
            {
                _attempts.TryRemove(ip, out _);
            }
        }
    }
}
   
