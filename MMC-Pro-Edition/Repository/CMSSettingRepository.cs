using Microsoft.EntityFrameworkCore;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;

namespace MMC_Pro_Edition.Repository
{
    public class CMSSettingRepository
    {
        private readonly IConfiguration _config;
        private readonly Onedb _con;
        private readonly DapperContext _dapper;
        private readonly HelperMethods _helper = new HelperMethods();

        public CMSSettingRepository(IConfiguration config, Onedb con, DapperContext dapper)
        {
            _config = config;
            _con = con;
            _dapper = new DapperContext(_config);
        }
        public async Task<CmssettingsDTO> GetCMSSetting()
        {
            var result = await _con.Cmssettings
                .Select(x => new CmssettingsDTO
                {
                    CmssettingId = x.CmssettingId,
                    IsAiEnabled = x.IsAiEnabled,
                })
                .FirstOrDefaultAsync();

            return result ?? new CmssettingsDTO
            {
                CmssettingId = 0,
                IsAiEnabled = false
            };
        }
    }
}
