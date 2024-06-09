using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Areas.Market.Repository;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;
using System.Diagnostics;

namespace MMC_Pro_Edition.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		
		public HomeController(ILogger<HomeController> logger, IConfiguration config, Onedb con, DapperContext dapper)
		{
			_config= config;
			_logger = logger;
			_con = con;
			_dapper= dapper;
			PagesViewModel.WebsiteId = 1;
		}
		[Authorize(Roles = UserRoles.User + "," + UserRoles.Admin + "," + UserRoles.PowerUser + "," + UserRoles.Accounts)]
		public IActionResult Index()
		{

            var web = new WebsiteSetupRepository(_config, _con, _dapper).Websites();
			if (web.Count==0)
			{
				return RedirectToAction("SetupAdmin", "WebsiteSetup");	
			}
			return View();
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
	}
}
