using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;
using Newtonsoft.Json;

namespace MMC_Pro_Edition.Repository
{
    public class AppDataUtility
    {
        private const string SessionKey = "SessionManager";
        private static IHttpContextAccessor _contextAccessor;

        public static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public static LoginVM SessionUser
        {
            get
            {
                var session = _contextAccessor?.HttpContext?.Session;
                var result = session?.GetString(SessionKey);
                return result == null ? null : JsonConvert.DeserializeObject<LoginVM>(result);
            }
            set
            {
                var session = _contextAccessor?.HttpContext?.Session;
                if (session != null)
                {
                    session.SetString(SessionKey, JsonConvert.SerializeObject(value));
                }
            }
        }
      
    }


}
