using Dapper;
using MMC_Pro_Edition.Areas.Market.ViewModels;
using MMC_Pro_Edition.Models;

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
	}
}
