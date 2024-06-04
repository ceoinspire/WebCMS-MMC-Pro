using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Areas.Market.Repository;
using MMC_Pro_Edition.Areas.Market.ViewModels;
using MMC_Pro_Edition.Models;

namespace MMC_Pro_Edition.Controllers
{
	public class CmsEmailController : Controller
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		//private readonly ContentRepository _conRepo;
		WebsiteModels vm = new WebsiteModels();
        public CmsEmailController(IConfiguration config, Onedb con, DapperContext dapper)
        {
			_config = config;
			_con = con;
			_dapper = new DapperContext(_config);
		}

        public IActionResult GetAllEmails()
		{
			return View();
		}
	}
}
