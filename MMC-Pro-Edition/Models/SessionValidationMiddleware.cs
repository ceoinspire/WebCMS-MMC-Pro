using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MMC_Pro_Edition.Models
{
    public class SessionValidationMiddleware
    {
        private readonly RequestDelegate _next;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public SessionValidationMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Invoke(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Session.GetString("CustomSessionId")))
            {
				var user = _httpContextAccessor.HttpContext.User;
				if (user.Identity.IsAuthenticated)
                {
					 await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme + "WEBCMS");
				}
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
