using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Areas.Market.Repository;
using MMC_Pro_Edition.Areas.Market.ViewModels;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;

namespace MMC_Pro_Edition.Controllers
{
	public class CmsEmailController : Controller
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		//private readonly ContentRepository _conRepo;
		private readonly CmsEmailRepository _email;
		PagesViewModel vm = new PagesViewModel();
		public CmsEmailController(IConfiguration config, Onedb con, DapperContext dapper)
		{
			_config = config;
			_con = con;
			_dapper = new DapperContext(_config);
			
			_email = new CmsEmailRepository(_config, _con);
		}

		public IActionResult GetAllEmails()
		{
			
			return View();
		}
		public IActionResult EmailList()
		{
			var res = _email.Emails(1);
			vm.Emails = res;
			return PartialView("/Views/CmsEmail/_PartialAllEmails.cshtml",vm);
		}
	}
}
