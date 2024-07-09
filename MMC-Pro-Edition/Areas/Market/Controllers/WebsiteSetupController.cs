using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Areas.Market.Repository;
using MMC_Pro_Edition.Areas.Market.ViewModels;
using MMC_Pro_Edition.Controllers;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;

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
		private readonly AccontRepository _ac;
		private readonly FileRepository _file;
		WebsiteModels vm = new WebsiteModels();
		PagesViewModel pvm = new PagesViewModel();
		public WebsiteSetupController(IConfiguration config, Onedb con, DapperContext dapper)
		{
			_config = config;
			_con = con;
			_dapper = new DapperContext(_config);
			_repo = new WebsiteSetupRepository(_config, _con, _dapper);
			_ac = new AccontRepository(_config,_con);
			_file = new FileRepository();
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

		[Route("/UserSetup")]
		public IActionResult UserSetup()
		{
			var res =_ac.GetAlUsers();
			pvm.LoginUsers = res;
			return View(pvm);
		}
		[Route("/WebSetup/AddUser")]
		public IActionResult AddUser()
		{
			return PartialView("/Areas/Market/Views/WebsiteSetup/AddUser.cshtml");
		}
		[Route("/Setup/CreateUser")]
		[HttpPost]
		public IActionResult CreateUser(IFormCollection form)
		{
			var firstName = form["firstName"];
			var lastName = form["lastName"];
			var email = form["email"];
			var mobile = form["mobile"];
			var password = form["password"];
			string ImageUrl = "";
			var file = form.Files["imageUrl"];

			if (file != null && file.Length > 0)
			{
				ImageUrl = _file.SaveImageMethod(file);
			}
			_ac.AddUser(email, firstName, lastName, password, mobile, ImageUrl);
			// Process other form data

			return Json(new { success = true });
		}
		[Route("/WebSetup/EditUser/{Id}")]
		public IActionResult EditUser(int Id)
		{
			var res = _ac.GetUserId(Id);
			pvm.LoginUser = res;
			return View("/Areas/Market/Views/WebsiteSetup/EditUser.cshtml",pvm);
		}
	}
}
