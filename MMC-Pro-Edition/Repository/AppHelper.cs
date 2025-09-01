using System.Web;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.ViewModel;
using Newtonsoft.Json;

namespace MMC_Pro_Edition.Repository
{
    public class AppHelper
    {
        public static string CreateSSOURL(int appId)
        {
            var setting = PagesViewModel.Settings.FirstOrDefault(x => x.ApplicationId == appId);
            var ssoLogin = new SSOLogin
            {
                UserName = AppDataUtility.SessionUser.UserName,
                Password = EncryptionPasses.Decrypt(AppDataUtility.SessionUser.Password, PassesCore.INIT_VECTOR, PassesCore.PASS_PHRASE, PassesCore.KEY_SIZE)

            };
            string encrypted = EncryptionPasses.RandomEncrypt(JsonConvert.SerializeObject(ssoLogin));
            string safeEncrypted = Uri.EscapeDataString(encrypted);

            string baseUrl = setting.ApplicationUrl.TrimEnd('/');
            string url = $"{baseUrl}/Account/Login?returnUrl={safeEncrypted}";

            return url;
        }

    }
    public class SSOLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
