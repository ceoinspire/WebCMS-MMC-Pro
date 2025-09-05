using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using MMC_Pro_Edition.Classes;
using System.Drawing;
using System.Web;

namespace MMC_Pro_Edition.Controllers
{
	
	public class AccountsController : Controller
    {
        private readonly AccontRepository _account;
        private readonly IConfiguration _config;
        private readonly Onedb _onedb;
		private readonly SettingsConfigurationRepository _setting;

		public AccountsController(IConfiguration config, Onedb onedb)
        {
            _config= config;
            _onedb = onedb;
            _account = new AccontRepository(_config, _onedb);
			_setting = new SettingsConfigurationRepository(_config, _onedb);
			var res = _setting.GetWebsiteData(PagesViewModel.WebsiteId);
			PagesViewModel.CompanyData = res;
		}

      
        public async Task<IActionResult> Login(string returnUrl)
        {
            if (CheckEncryption(returnUrl))
            {
                string base64 = Uri.UnescapeDataString(returnUrl);
                string decrypted = EncryptionPasses.RandomDecrypt(base64);
                LoginVM user = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginVM>(decrypted);
                var res =  _account.ValidateLoginDetails(user);
                if (res != null)
                {
                    await _account.SigninAsync(res, HttpContext);
                    AppDataUtility.SessionUser = res;
                    byte[] userarray = JsonSerializer.SerializeToUtf8Bytes(res);
                    HttpContext.Session.Set("LoginUser", userarray);
                    return Redirect("/");

                }
            }
            TempData["ReturnURL"] = returnUrl;
            return View();
        }
        private bool CheckEncryption(string returnUrl)
        {
            bool isEncrypted = false;
            string decrypted = null;

            if (!string.IsNullOrEmpty(returnUrl))
            {
                try
                {
                    string unescaped = Uri.UnescapeDataString(returnUrl);
                    decrypted = EncryptionPasses.RandomDecrypt(unescaped);

                    // if decryption didn't throw, assume it's valid
                    if (!string.IsNullOrEmpty(decrypted))
                        isEncrypted = true;
                }
                catch
                {
                    isEncrypted = false; // not encrypted
                }
            }

            return isEncrypted;
        }

        public string DecryptText(string encvalue)
        {
            string text = EncryptionPasses.Decrypt(encvalue, PassesCore.INIT_VECTOR, PassesCore.PASS_PHRASE, PassesCore.KEY_SIZE);
            return text;
        }
        public string Encrypt(string encvalue)
        {
            string text = EncryptionPasses.Encrypt(encvalue, PassesCore.INIT_VECTOR, PassesCore.PASS_PHRASE, PassesCore.KEY_SIZE);
            return text;
        }
        public async Task<IActionResult> ValidateUser(LoginVM model)
        {
            string url = (string)TempData["ReturnURL"];
            var enc = _account.ValidateLoginDetails(model);
            if (enc!=null)
            {
                await _account.SigninAsync(enc, HttpContext);

                AppDataUtility.SessionUser = enc;
                byte[] userarray = JsonSerializer.SerializeToUtf8Bytes(enc);
                HttpContext.Session.Set("LoginUser", userarray);
            return Json(new { statusCode = "200",returnUrl=url });

            }
            return Json(new { statusCode = "300", returnUrl = url });

        }
        [Route("/Accounts/Logout")]
		public async Task<IActionResult> Logout()
        {
            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme + _config.GetValue<string>("SystemSettings:CookieName"));

            // Redirect to the home page or any other desired page after logout
            return RedirectToAction("Index", "Home");
        }
		public IActionResult UserProfile()
        {
            return View();
        }
		[Route("/Users/ActiveUnActive")]
        public IActionResult ActiveUnActive(LoginVM model)
        {
            try
            {
				bool isSaved = _account.ActiveDeactiveUser(model);
				if (isSaved)
				{
					return Json(new { statusCode = "200" });
				}
				else
				{
					return Json(new { statusCode = "300" });
				}
			}
            catch (Exception e)
            {
				return Json(new { statusCode = "300",Message=e.Message });
			}
        

			
        }
		[Route("/User/UpdateProfile")]
        public IActionResult UpdateUser(UpdateProfileVM model)
        {
            try
            {
                var res = _account.UpdateAccount(model);
				return Json(new { statusCode = "200" });

			}
			catch (Exception e)
            {
				return Json(new { statusCode = "300", Message=e.Message });
			}
           
        }
        
        public IActionResult UpdateProfile(FileUploadVM model)
        {
            var res = _account.UpdateProfilePhoto(model);
            return Json(new { statusCode = "200" });
        }

        [HttpGet]
        [Route("/Account/SSO/{key}")]
        public async Task<IActionResult> SSO(string key)
        {
            string base64 = Uri.UnescapeDataString(key);
            string decrypted = EncryptionPasses.RandomDecrypt(base64);
            LoginVM user = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginVM>(decrypted);
            var res = await _account.SSOValidateLogin(user);
            if (res != null)
            {
                await _account.SigninAsync(res, HttpContext);
                AppDataUtility.SessionUser = res;
                byte[] userarray = JsonSerializer.SerializeToUtf8Bytes(res);
                HttpContext.Session.Set("LoginUser", userarray);
                //if (res.RoleName=="SuperAdmin")
                //{
                //    url = "/adminPanel";

                //}
                return Redirect("/");

            }
            else
            {
                return View();
            }
        }
    }
}
