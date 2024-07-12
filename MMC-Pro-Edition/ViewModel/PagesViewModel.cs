using MMC_Pro_Edition.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MMC_Pro_Edition.ViewModel
{
	public class PagesViewModel
	{
        public static int  WebsiteId { get; set; }
        public static SetLoginVMStatic StaticLoginDetail { get; set; }
		public List<ContentVM>? ContentTypeSlugs { get; set; }
		public List<ChildContentVM>? ChildContents { get; set; }

		public List<ContentTypeVM>? ContentTypeVM { get; set; }
		public ContentTypeVM? ContentType { get; set; }

		public ContentVM? ContentTypeSlug { get; set; }
		public List<ContentCategoryVM>? Categories { get; set; }
		public int? ContentId { get; set; }
        public List<LoginVM> LoginUsers { get; set; }
        public LoginVM LoginUser { get; set; }
        public List<ReviewVM> Reviews { get; set; }

    }



	#region Content
	public class ContentVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageSource { get; set; }
		public string Thumbnail { get; set; }
		public DateTime? CreatedOn { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public int? WebSiteId { get; set; }
		public int? ContentTypeId { get; set; }
		public string OtherTitle { get; set; }
		public string MetaDescription { get; set; }
		public string ShortDescription { get; set; }
		public string OtherShortDescription { get; set; }
		public string OtherDescription { get; set; }
		public int? Priority { get; set; }
		public string Icon { get; set; }
		public string MetaTitle { get; set; }
		public string HeaderPhoto { get; set; }
		public string ContentSlug { get; set; }
		public string FwdUrl { get; set; }
		public string MetaKeyword { get; set; }
        public DateTime? Date { get; set; }
        public List<MediaManager> PhotoList { get; set; }
		public ContentTypeVM ContentTypeVM { get; set; }
        public ChildContentVM ChildContent { get; set; }
        public List<CMSContentSharecCategoryVM>? SharedCategory { get; set; }
    }
	public class ChildContentVM
	{
		public int ChildContentId { get; set; }
		public string ContentTitle { get; set; }

		public string OtherTitle { get; set; }

		public int? Priority { get; set; }
		public DateTime? CreatedOn { get; set; }

		public DateTime? Date { get; set; }

		public DateTime? ModifiedOn { get; set; }

		public int? Author { get; set; }

		public string Shortdescription { get; set; }

		public string Description { get; set; }

		public string OtherShortDescription { get; set; }

		public string Icon { get; set; }

		public string ImageSource { get; set; }

		public string Thumbnail { get; set; }

		public int? WebsiteId { get; set; }

		public string MetaTitle { get; set; }

		public string MetaDescription { get; set; }

		public string MetaKeywords { get; set; }

		public string HeaderPhoto { get; set; }
		public string FwdUrl { get; set; }

		public int? ContentId { get; set; }
		public string ContentSlug { get; set; }
	}
	public class MediaManager
	{
		public int Id { get; set; }
		public string? URL { get; set; }
		public string? Caption { get; set; }
		public int? Priority { get; set; }
		public int? ContentId { get; set; }
	}
	public class ContentTypeVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string ContentTypeSlug { get; set; }

    }
	public class ContentCategoryVM
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Slug { get; set; }
		public string TypeName { get; set; }
	}
	public class CMSContentSharecCategoryVM
	{
		public int Id { get; set; }

		public int? ContentId { get; set; }

		public int? CategoryId { get; set; }
	}
	#endregion
	public class UpdateCategoryVM
	{
        public List<string>? Category { get; set; }
        public int? ContentId { get; set; }
    }


	public class FileUploadVM
	{
		public IFormFile File { get; set; }
		public string ContentId { get; set; }
	}



	#region LoginRelevant
	public class LoginVM
	{
		public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
		public string? Password { get; set; }
		public string? ValidationToken { get; set; }
		public bool? IsActive { get; set; }
		public List<RolesVM>? Roles { get; set; }
		public int? PersonId { get; set; }
		public string? Status { get; set; }
		public PersonVM Person { get; set; }
    }
	public class PersonVM
	{
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MobileNumber { get; set; }

        public string? Cnic { get; set; }
        public string? SocialSecurity { get; set; }
		public string ImageUrl { get; set; }
		public string? Email { get; set; }
        public List<LaneAddressesVM>? Addresses { get; set; }
    }
	public class SetLoginVMStatic
	{
		public string? UserName { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }

	}
	public  class LaneAddressesVM
	{
		public int AddressId { get; set; }
		public string? LaneAddressOne { get; set; }
		public string? LaneAddressTwo { get; set; }
		public string? Area { get; set; }
		public string? FamousPlace { get; set; }

		public int? PersonId { get; set; }

		public CitiesVM? City { get; set; }
        public int CityId { get; set; }

        public string? AddressType { get; set; }


	}
	public  class CitiesVM
	{
		public int CityId { get; set; }
		public string? CityName { get; set; }
		public CountriesVM? Country { get; set; }
        public int CountryId { get; set; }
    }
	public  class CountriesVM
	{
		public int CountryId { get; set; }
		public string? CountryName { get; set; }
	}


	public class RolesVM
	{
		public int Id { get; set; }
		public string? Name { get; set; }
	}
	public class UpdateProfileVM
	{
        public int Id { get; set; }
        public string? Password { get; set; }
		public string? Email { get; set; }
		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? Mobile { get; set; }

		public string? CNIC { get; set; }
		public string? SocialSecurity { get; set; }
	}
	#endregion
	#region Reviews
	public class ReviewVM
	{
		public int ReviewId { get; set; }

		public string? Comment { get; set; }

		public short? Rating { get; set; }
		public DateTime? CreatedOn { get; set; }

		public int? LoginUserId { get; set; }

		public bool? IsPublished { get; set; }

		public int? ApprovedBy { get; set; }
		public string UserIp { get; set; }
		public string UserBrowser { get; set; }

		public int? ContentId { get; set; }
        public List<CommentVM> Comments { get; set; }
    }
	public class CommentVM
	{
		public int CommentId { get; set; }

		public string? Comment { get; set; }
		public DateTime? CreatedOn { get; set; }

		public int? LoginUser { get; set; }

		public bool? IsPublished { get; set; }

		public int? ApprovedBy { get; set; }
		public string? UserIp { get; set; }
		public string? UserBrowser { get; set; }

		public int? ReviewId { get; set; }

	}
}
	#endregion

