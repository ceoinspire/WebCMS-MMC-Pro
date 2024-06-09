namespace MMC_Pro_Edition.Models
{
    public class SessionValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Session.GetString("CustomSessionId")))
            {
                string customSessionId = GenerateCustomSessionId();
                context.Session.SetString("CustomSessionId", customSessionId);
            }

            await _next(context);
        }

        private string GenerateCustomSessionId()
        {
            // Implement your custom session ID generation logic here
            // For example, you can use GUIDs, random strings, or any other method
            return Guid.NewGuid().ToString();
        }
    }
}
