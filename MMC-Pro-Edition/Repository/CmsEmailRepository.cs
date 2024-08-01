using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;

namespace MMC_Pro_Edition.Repository
{
	public class CmsEmailRepository
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		public CmsEmailRepository(IConfiguration config, Onedb con)
		{
			_config = config;
			_con = con;
			_dapper = new DapperContext(_config);
		}
		public List<CMSEmailVM> Emails(int WebsiteId)
		{
			return _con.CmsEmail.Where(x => x.WebsiteId == WebsiteId).Select(x => new CMSEmailVM
			{
				EmailId = x.EmailId,
				EmailSender = x.EmailSender,
				EmailBody = x.EmailBody,
				EmailSubject = x.EmailSubject,
				IsSend = x.IsSend,
				DateCreated = x.DateCreated,
				FirstName = x.FirstName,
				LastName = x.LastName,
				Mobile = x.Mobile,
				LandLine = x.LandLine
			}).ToList();
		}
	}
}
