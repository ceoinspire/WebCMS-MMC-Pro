using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MMC_Pro_Edition.Areas.Market.ViewModels
{
	public class WebsiteModels
	{
        public List<WebsiteVM> Websites { get; set; }
		public WebsiteVM Website { get; set; }
		public int WebsiteId { get; set; }
	}
	public class WebsiteVM
	{
		public int WebsiteId { get; set; }
		public string? WebsiteName { get; set; }
		public string? WebsiteLogo { get; set; }
		public string? WebsiteLogoTwo { get; set; }
		public string? FavIcon { get; set; }
		public string? WebsiteDescription { get; set; }
		public string? WebsiteTitle { get; set; }
		public string? SupportEmail { get; set; }
		public List<WebsiteDataVM>? WebsiteData { get; set; }
	}
	public class WebsiteDataVM
	{
		public int WebsiteDataId { get; set; }

		public string? Title { get; set; }

		public string? Value { get; set; }

		public int WebsiteId { get; set; }

	}
}
