using MMC_Pro_Edition.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MMC_Pro_Edition.Areas.Market.ViewModels;
using System.Drawing.Printing;

namespace MMC_Pro_Edition.ViewModel
{
	public class PagesViewModel
	{
		public static int WebsiteId { get; set; }
		public static WebsiteVM CompanyData { get; set; }
		// public static SetLoginVMStatic StaticLoginDetail { get; set; }
		public List<ContentVM>? ContentTypeSlugs { get; set; }
		public List<ChildContentVM>? ChildContents { get; set; }
		public List<CountriesVM> Countries { get; set; }
		public List<ContentTypeVM>? ContentTypeVM { get; set; }
		public List<LinkedContent> LinkedItems { get; set; }
		public ContentTypeVM? ContentType { get; set; }
		public DTOCMSEmail DtoEmails { get; set; }
		public ContentVM? ContentTypeSlug { get; set; }
		public List<ContentCategoryVM>? Categories { get; set; }
		public ContentCategoryVM? Category { get; set; }
        public static List<SettingVM> Settings { get; set; }
        public int? ContentId { get; set; }
		public List<LoginVM> LoginUsers { get; set; }
		public LoginVM LoginUser { get; set; }
		public List<ReviewVM> Reviews { get; set; }
		public List<CMSEmailVM> Emails { get; set; }
		public CMSEmailVM Email { get; set; }
	}



	#region Content
	public class ContentVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Tagline { get; set; }

		public string OverView { get; set; }

		public string VideoLink { get; set; }
		public string Note { get; set; }
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
		public List<LinkedContent> LinkedContentItems { get; set; }
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
	public class LinkedContent
	{
		public string Key { get; set; }
		public int Id { get; set; }
		public int LinkedItemId { get; set; }
		public string Name { get; set; }
		public string Tagline { get; set; }

		public string OverView { get; set; }

		public string VideoLink { get; set; }
		public string Note { get; set; }
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
		public List<LinkChildVM> ChildContent { get; set; }
	}
	public class LinkChildVM
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
        public string RoleName { get; set; }
        public string? UserName { get; set; }
		public string? Password { get; set; }
		public string? ValidationToken { get; set; }
		public bool? IsActive { get; set; }
		public List<RolesVM>? Roles { get; set; }
		public int? PersonId { get; set; }
		public string? Status { get; set; }
		public PersonVM Person { get; set; }
	}
    public partial class PersonVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }

        public string Cnic { get; set; }
        public string SocialSecurity { get; set; }
        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }

        public bool? IsActive { get; set; }
        public int CityId { get; set; }
        public string? Address { get; set; }
        public Guid? BranchId { get; set; }
        //public string? BranchName { get; set; }
        //public string? BranchCode { get; set; }
        //public string? OrganizationName { get; set; }
        public BranchVM Branch { get; set; }
        public List<LaneAddressesVM>? Addresses { get; set; }
    }
    public partial class LaneAddressVM
    {
        public int AddressId { get; set; }

        public string LaneAddressOne { get; set; }

        public string LaneAddressTwo { get; set; }

        public string Area { get; set; }

        public string FamousPlace { get; set; }

        public int? PersonId { get; set; }

        public int? CityId { get; set; }
        public int StateProvinceId { get; set; }
        public int CountryId { get; set; }
        public string? AddressType { get; set; }
        public CityVM? City { get; set; }
    }
    public partial class CityVM
    {
        public int CityId { get; set; }

        public string? CityName { get; set; }

        public int? StateProvinceId { get; set; }

        public int? CountryId { get; set; }
        public StateProvinceVM? StateProvince { get; set; }

    }
    public partial class StateProvinceVM
    {
        public int StateProvinceId { get; set; }

        public string StateProvinceName { get; set; }

        public int? CountryId { get; set; }
        public CountryVM? Country { get; set; }
    }
    public partial class CountryVM
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

    }
    public class LaneAddressesVM
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
	public class CitiesVM
	{
		public int CityId { get; set; }
		public string? CityName { get; set; }
		public CountriesVM? Country { get; set; }
		public int CountryId { get; set; }
	}
	public class CountriesVM
	{
		public int CountryId { get; set; }
		public string? CountryName { get; set; }
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
	#endregion

	#region CmsEmailVM
	public class DTOCMSEmail
	{
		public int WebsiteId { get; set; }
		public int pageNumber { get; set; } 
		public string searchQuery { get; set; }
		public int pageSize { get; set; }
        public int TotalPages { get; set; }
        public long EmailCount { get; set; } 
        public bool ascending  { get; set; }
        public List<CMSEmailVM> Emails { get; set; }
       
    }
	public class FormDataVM
	{
		public int EmailId { get; set; }
	}
	public class CMSEmailVM
	{
		public int EmailId { get; set; }
		public int? WebsiteId { get; set; }
		public string EmailSubject { get; set; }
		public string EmailSender { get; set; }
		public string EmailBody { get; set; }
		public DateTime? DateCreated { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public string Mobile { get; set; }
		public string LandLine { get; set; }
		public bool? IsSend { get; set; }
		public bool? IsRead { get; set; }
		public string StatusMessage { get; set; }
		public virtual Website Website { get; set; }
		public List<CMSEmailAttachmentVM> Attachments { get; set; }
	}

	public partial class CmsemailSentVM
	{
		public int EmailSentId { get; set; }
		public string ToEmailAddress { get; set; }

		public string FromEmailAddress { get; set; }
		public string Subject { get; set; }

		public string Body { get; set; }

		public DateTime SentDateTime { get; set; }

		public bool IsSent { get; set; }

		public bool IsRead { get; set; }

		public int? UserId { get; set; }

		public DateTime? CreatedDate { get; set; }

		public int? EmailId { get; set; }

	}
	public class CMSEmailAttachmentVM
	{
		public int AttachmentId { get; set; }

		public int? EmailId { get; set; }

		public string AttachmentUrl { get; set; }
	}








    #endregion

    #region WebsiteSettingsRelevant
    //public class WebsiteVM
    //{
    //	public int WebsiteId { get; set; }
    //	public string? WebsiteName { get; set; }

    //	public string? WebsiteLogo { get; set; }

    //	public string? WebsiteLogoTwo { get; set; }

    //	public string? FavIcon { get; set; }

    //	public string? WebsiteDescription { get; set; }

    //	public string? WebsiteTitle { get; set; }

    //	public string? SupportEmail { get; set; }

    //}

    #endregion
    public partial class SettingVM
    {
        public int SettingsId { get; set; }

        public int? ApplicationId { get; set; }

        public string ApplicationUrl { get; set; }

        public bool? IsActive { get; set; }

        public Guid? BranchId { get; set; }
        public string ApplicationName { get; set; }

    }
    public partial class BranchVM
    {
        public Guid BranchId { get; set; }

        public string BranchName { get; set; }
        public string OrganizationName { get; set; }
        public int? OrganizationId { get; set; }

        public short? BusinessCategoryId { get; set; }

        public int? BusinessStoreTypeId { get; set; }

        public short? BusinessEntityTypeId { get; set; }

        public string BranchCode { get; set; }
        public OrganizationVM Organization { get; set; }
    }
    public  class RolesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool? IsActive { get; set; }
    }
    public partial class OrganizationVM
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string BranchCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }

}





