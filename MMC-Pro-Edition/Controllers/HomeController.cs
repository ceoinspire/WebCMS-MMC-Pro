using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Areas.Market.Repository;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;
using System.Diagnostics;

namespace MMC_Pro_Edition.Controllers
{
	
	public class HomeController : Controller
	{
        #region Constructor

     
        private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		private readonly SettingsConfigurationRepository _setting;
        private readonly IDashboardRepository _dashboardRepo;
        public HomeController(ILogger<HomeController> logger, IConfiguration config, Onedb con, DapperContext dapper, IDashboardRepository dashboardRepo)
		{
			_config= config;
			_logger = logger;
			_con = con;
			_dapper= dapper;
			_setting = new SettingsConfigurationRepository(_config, _con);
			PagesViewModel.WebsiteId = 1;
			var res = _setting.GetWebsiteData(PagesViewModel.WebsiteId);
			PagesViewModel.CompanyData = res;
            PagesViewModel.Settings ??= _setting.GetSettings().GetAwaiter().GetResult();
			_dashboardRepo = dashboardRepo;
        }
        #endregion

        [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin + "," + UserRoles.PowerUser + "," + UserRoles.Accounts)]
		public async Task<IActionResult> Index()
		{

            var web = new WebsiteSetupRepository(_config, _con, _dapper).Websites();
			if (web.Count==0)
			{
				return RedirectToAction("SetupAdmin", "WebsiteSetup");	
			}
			var model = await _dashboardRepo.GetDashboardDataAsync();
            return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		[Route("Error/{statusCode}")]
		public IActionResult HandleErrorCode(int statusCode)
		{
			return View();

			//switch (statusCode)
			//{
			//	case 404:
			//	case 500:
			//		return View("ServerError");
			//	default:
			//		return View("GenericError");
			//}
		}
	}
}
