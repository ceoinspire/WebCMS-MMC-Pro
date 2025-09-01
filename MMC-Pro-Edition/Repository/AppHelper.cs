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
            var setting = PagesViewModel.Settings.Where(x => x.ApplicationId == appId).FirstOrDefault();
            string encrypted = EncryptionPasses.RandomEncrypt(JsonConvert.SerializeObject(AppDataUtility.SessionUser));
            string safeEncrypted = Uri.EscapeDataString(encrypted);

            string url = $"{setting.ApplicationUrl}Account/SSO/{safeEncrypted}";
            return url;
        }
    }
}
