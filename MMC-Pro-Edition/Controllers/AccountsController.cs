using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;

namespace MMC_Pro_Edition.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccontRepository _account;
        private readonly IConfiguration _config;
        private readonly Onedb _onedb;
        public AccountsController(IConfiguration config, Onedb onedb)
        {
            _config= config;
            _onedb = onedb;
            _account = new AccontRepository(_config, _onedb);
        }
        public IActionResult Login(string returnUrl)
        {
            return View();
        }
        public async Task<IActionResult> ValidateUser(LoginVM model)
        {
            var enc = _account.ValidateLoginDetails(model);
            if (enc!=null)
            {
                await _account.SigninAsync(enc, HttpContext);
            }
            SetLoginVMStatic vmst = new SetLoginVMStatic();

            vmst.Name = enc.Person.FirstName + enc.Person.LastName;
            vmst.Email = enc.UserName;
            PagesViewModel.StaticLoginDetail = vmst;
            return Json(new { statusCode = "200" });
        }
        public async Task<IActionResult> Logout()
        {
            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme + "WEBCMS");

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
    
    
    
    }
}
