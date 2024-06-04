using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Areas.Market.ViewModels;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;

namespace MMC_Pro_Edition.Areas.Market.Repository
{
	public class WebsiteSetupRepository
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		//private readonly HelperMethods _helper = new HelperMethods();
		public WebsiteSetupRepository(IConfiguration config, Onedb con, DapperContext dapper)
		{
			_config = config;
			_con = con;
			_dapper = new DapperContext(_config);
		}
		public List<WebsiteVM> Websites()
		{
			return _con.Website.Select(x => new WebsiteVM
			{
				WebsiteId = x.WebsiteId,
				FavIcon = x.FavIcon,
				SupportEmail = x.SupportEmail,
				WebsiteDescription = x.WebsiteDescription,
				WebsiteLogo = x.WebsiteLogo,
				WebsiteLogoTwo = x.WebsiteLogoTwo,
				WebsiteTitle = x.WebsiteTitle

			}).ToList();
		}

		public int CreateWebsite(string name)
		{
			int maxId;

			if (_con.Website.Any())
			{
				maxId = _con.Website.Max(fm => fm.WebsiteId) + 1;
			}
			else
			{
				// If there are no records in the table, set maxId to 1 or any initial value you prefer.
				maxId = 1;
			}
			Website web = new Website();
			web.WebsiteId = maxId;
			web.WebsiteName = name;
			_con.Website.Add(web);
			_con.SaveChanges();
			return maxId;
		}

		public WebsiteVM Website(int Id)
		{
			return _con.Website.Where(x => x.WebsiteId == Id).Select(x => new WebsiteVM
			{
				WebsiteName=x.WebsiteName,
				WebsiteId = x.WebsiteId,
				FavIcon = x.FavIcon,
				SupportEmail = x.SupportEmail,
				WebsiteDescription = x.WebsiteDescription,
				WebsiteLogo = x.WebsiteLogo,
				WebsiteLogoTwo = x.WebsiteLogoTwo,
				WebsiteTitle = x.WebsiteTitle
				, WebsiteData=_con.WebsiteData.Where(webdata=>webdata.WebsiteId==Id).Select(y=>new WebsiteDataVM
				{
					 WebsiteDataId=y.WebsiteDataId, Title=y.Title, Value=y.Value, WebsiteId= y.WebsiteId 
				}).ToList(),
			}).FirstOrDefault();
		}

		public bool UpdateWebsite(int Id,string Title, string Name, string SupportEmail, string Desc)
		{
			var web = _con.Website.Where(x => x.WebsiteId == Id).FirstOrDefault();
			web.WebsiteName = Name;
			web.WebsiteTitle = Title;
			web.SupportEmail = SupportEmail;
			web.WebsiteDescription = Desc;
			_con.SaveChanges();
			return true;

		}
		public bool CreateDataType(int Id, string title, string Value)
		{
			int maxId;

			if (_con.WebsiteData.Any())
			{
				maxId = _con.WebsiteData.Max(fm => fm.WebsiteDataId) + 1;
			}
			else
			{
				// If there are no records in the table, set maxId to 1 or any initial value you prefer.
				maxId = 1;
			}
			WebsiteData webdata = new WebsiteData();
			webdata.WebsiteDataId = maxId;
			webdata.WebsiteId = Id;
			webdata.Title = title;
			webdata.Value = Value;
			_con.WebsiteData.Add(webdata);
			_con.SaveChanges();
			return true;
		}












	}



}
