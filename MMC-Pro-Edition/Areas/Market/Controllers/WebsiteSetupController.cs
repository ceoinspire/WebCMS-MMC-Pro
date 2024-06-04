using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Areas.Market.Repository;
using MMC_Pro_Edition.Areas.Market.ViewModels;
using MMC_Pro_Edition.Controllers;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;

namespace MMC_Pro_Edition.Areas.Market.Controllers
{
	[Area("Market")]
	public class WebsiteSetupController : Controller
	{
		private readonly WebsiteSetupRepository _repo;
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		//private readonly ContentRepository _conRepo;
		WebsiteModels vm = new WebsiteModels();
		public WebsiteSetupController(IConfiguration config, Onedb con, DapperContext dapper)
		{
			_config = config;
			_con = con;
			_dapper = new DapperContext(_config);
			_repo = new WebsiteSetupRepository(_config, _con, _dapper);
			//_conRepo=new ContentRepository(_config,_con,_dapper);
		}

		[Route("/WebsiteSetup/SetupAdmin")]
		public IActionResult SetupAdmin()
		{
			vm.Websites = _repo.Websites();
			return View(vm);
		}

		[Route("/WebsiteSetup/AddWebsite")]
		public IActionResult AddWebsite()
		{
			return PartialView("/Areas/Market/Views/WebsiteSetup/_PartialAddWebsite.cshtml");
		}
		[Route("/CreateWebsite")]
		public IActionResult CreateWebsite(string WebsiteName)
		{
			int webId = _repo.CreateWebsite(WebsiteName);
			return Json(new { statusCode = "200", WebsiteId = webId });
		}
		[Route("/EditWebsite/{Id}")]
		public IActionResult EditWebsite(int Id)
		{
			vm.Website = _repo.Website(Id);
			return View(vm);
		}
		[Route("/WebsiteSetup/UpdateWebsite")]
		public IActionResult UpdateWebsite(int Id,string Title,string Name,string SupportEmail, string Desc)
		{
			try
			{
				_repo.UpdateWebsite( Id,Title,Name,SupportEmail,Desc);
				return Json(new { statusCode = "200" });
			}
			catch (Exception)
			{
				return Json(new { statusCode = "300" });
			}
		}
		[Route("/WebsiteData/AddDataView/{Id}")]
		public IActionResult AddDataView(int Id)
		{
			vm.WebsiteId = Id;
			return PartialView("/Areas/Market/Views/WebsiteSetup/_PartialAddData.cshtml",vm);
		}
		[Route("/CreateWebsiteData")]
		public IActionResult CreateWebsiteData(int WebsiteId,string Title,string Value)
		{
			var res = _repo.CreateDataType(WebsiteId,Title, Value);
			return Json(new {statusCode="200" });
		}
	}
}
