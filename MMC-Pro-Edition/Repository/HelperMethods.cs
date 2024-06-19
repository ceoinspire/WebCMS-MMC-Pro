using System.Text.RegularExpressions;

namespace MMC_Pro_Edition.Repository
{
	public class HelperMethods
	{
		Random random = new Random(5);
        public string CreateSlug(string value)
        {
            var row = value.Replace(' ', '-').ToLower();
            var sanitized = Regex.Replace(row, "[^a-z0-9-]", string.Empty);
            string result = sanitized + "-" + random.Next(1000, 10000);
            return result;
        }
    }
}
