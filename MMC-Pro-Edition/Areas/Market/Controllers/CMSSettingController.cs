using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Areas.Market.Repository;
using MMC_Pro_Edition.Areas.Market.ViewModels;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;

namespace MMC_Pro_Edition.Areas.Market.Controllers
{
    [Area("Market")]
    [Route("[controller]/[action]")]
    [Authorize(Roles = UserRoles.Admin + "," + UserRoles.PowerUser)]

    public class CMSSettingController : Controller
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
        private readonly CMSSettingRepository _cmssettings;
        public CMSSettingController(IConfiguration config, Onedb con, DapperContext dapper)
        {
            _config = config;
            _con = con;
            _dapper = new DapperContext(_config);
            _repo = new WebsiteSetupRepository(_config, _con, _dapper);
            _ac = new AccontRepository(_config, _con);
            _file = new FileRepository();
            //_conRepo=new ContentRepository(_config,_con,_dapper);
            _cmssettings = new CMSSettingRepository(_config, _con, _dapper);
        }

        public async Task<IActionResult> SettingsPage()
        {
            var result = await _cmssettings.GetCMSSetting();
            vm.CmsSettings = result;
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSetting([FromForm]CmssettingsDTO model)
        {
            var result = await _cmssettings.UpdateCMSSettings(model);
            if (result)
            {
                return Json(new { statusCode = "200" });
            }
            else
            {
                return Json(new { statusCode = "300" });
            }
        }
    }
}
