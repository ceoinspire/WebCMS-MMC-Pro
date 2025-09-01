using Dapper;
using Microsoft.EntityFrameworkCore;
using MMC_Pro_Edition.Areas.Market.ViewModels;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;

namespace MMC_Pro_Edition.Repository
{
	public class SettingsConfigurationRepository
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dap;
		public SettingsConfigurationRepository(IConfiguration config, Onedb con)
		{
			_config = config;
			_con = con;
			_dap = new DapperContext(_config);
		}
		
		public WebsiteVM GetWebsiteData(int WebsiteId)
		{
			using (var conn =_dap.CreateConnection())
			{
				var query = $"SELECT * FROM SYSTEM.Website where WebsiteId={WebsiteId}";
				var res = conn.Query<WebsiteVM>(query).FirstOrDefault();
				return res;
			}
		}
        public async Task<List<SettingVM>> GetSettings()
        {
            return await _con.Settings.Where(x => x.IsActive == true).Select(x => new SettingVM
            {
                ApplicationId = x.ApplicationId,
                ApplicationName = x.ApplicationName,
                ApplicationUrl = x.ApplicationUrl,
                SettingsId = x.SettingsId,
                BranchId = x.BranchId,
                IsActive = x.IsActive
            }).ToListAsync();
        }
    }
}
