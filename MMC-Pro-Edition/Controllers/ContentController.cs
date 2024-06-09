
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;

namespace MMC_Pro_Edition.Controllers
{

	[Authorize(Roles = UserRoles.User + "," + UserRoles.Admin + "," + UserRoles.PowerUser + "," + UserRoles.Accounts)]
	public class ContentController : Controller
	{
		#region Constructor
		PagesViewModel vm = new PagesViewModel();
		private readonly ContentRepository _repo;
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		public ContentController(IConfiguration config, Onedb con, DapperContext dapper)
		{
			_config = config;
			_con = con;

			_repo = new ContentRepository(_config, _con, _dapper);
		}
		#endregion
		[Route("/Content/ContentPage")]
		public IActionResult ContentPage()
		{
			return View();
		}
		[Route("/Content/GetContentList")]
		public IActionResult GetContentList()
		{
			int WebId = PagesViewModel.WebsiteId;

            vm.ContentTypeSlugs = _repo.GetContents(WebId);
			return PartialView("~/Views/Content/_GetContents.cshtml", vm);
		}


		public IActionResult AddNewContent()
		{
			vm.ContentTypeVM = _repo.ContentType();
			return PartialView("~/Views/Content/_AddContent.cshtml", vm);
		}
		[HttpPost]
		public IActionResult CreateContent(string cTitle, string cType)
		{
			var userid = User.Claims.FirstOrDefault(c=>c.Type=="UserId");
			int WebId = PagesViewModel.WebsiteId;
			var result = _repo.CreateContent(cTitle, cType,Convert.ToInt32(userid.Value),WebId);
			string[] res = result.Split(',');
			if (res[0] == "true")
			{

				return Json(new { statusCode = "200", ResponseMessage = "Item Save Successfully", itemId = int.Parse(res[1]) });
			}
			else
			{
				return Json(new { statusCode = "300", ResponseMessage = "Item Cannot Save" });
			}
		}
		[HttpGet]
		public IActionResult EditContent(int Id)
		{
			vm.ContentTypeSlug = _repo.GetContentbyId(Id);
			return View(vm);
		}
		[Route("/Content/ContentData/{ContentId}")]
		public IActionResult ContentData(int ContentId)
		{
			vm.ContentTypeSlug = _repo.GetContentbyId(ContentId);
			vm.Categories = _repo.GetAllCategoriesbyType(ContentId);

			return PartialView("~/Views/Content/_BasicContent.cshtml", vm);
		}

		[Route("Content/UpdateBasicContent")]
		public IActionResult UpdateBasicContent(ContentVM model)
		{
			var response = _repo.UpdateBasicContent(model);
			if (response)
			{
				return Json(new { statusCode = "200" });

			}
			else
			{
				return Json(new { statusCode = "300" });

			}
		}

		[Route("/Content/ContentDescData/{ContentId}")]
		public IActionResult ContentDescData(int ContentId)
		{
			vm.ContentTypeSlug = _repo.GetContentbyId(ContentId);
			return PartialView("~/Views/Content/_ContentDescData.cshtml", vm);
		}
		[Route("Content/UpdateDescContent")]
		public IActionResult UpdateDescContent(ContentVM model)
		{
			var response = _repo.UpdateDescContent(model);
			return Json(new { statusCode = "OK" });
		}
		[Route("/Content/GetPhotoUpdatePage/{ContentId}")]
		public IActionResult GetPhotoUpdatePage(int ContentId)
		{
			vm.ContentTypeSlug = _repo.GetContentbyId(ContentId);
			return PartialView("~/Views/Content/_GetPhotoUpdatePage.cshtml", vm);
		}
		[Route("/Content/GetChildItems/{ContentId}")]
		public IActionResult GetChildItems(int ContentId)
		{
			vm.ContentTypeSlugs = _repo.GetChildContent(ContentId);
			vm.ContentId = ContentId;
			return PartialView("~/Views/Content/_GetChildItems.cshtml", vm);
		}
		[Route("/Content/AddChildContent/{ContentId}")]
		public IActionResult AddChildContent(int ContentId)
		{
			vm.ContentTypeVM = _repo.ContentType();
			vm.ContentId = ContentId;
			return PartialView("~/Views/Content/_AddChildContent.cshtml", vm);
		}
		[HttpPost]
		public IActionResult CreateChildContent(string cTitle, string cType, string parentId)
		{
            var userid = User.Claims.FirstOrDefault(c => c.Type == "UserId");
            int WebId = PagesViewModel.WebsiteId;
            var result = _repo.CreateChildContent(cTitle, cType, parentId, Convert.ToInt32(userid.Value), WebId);
			if (result == true)
			{

				return Json(new { statusCode = "200" });
			}
			else
			{
				return Json(new { statusCode = "300" });
			}
		}

		[Route("/Content/GetContentTypes")]
		public IActionResult GetContentTypes()
		{
			vm.ContentTypeVM = _repo.ContentType();
			return View(vm);
		}

		public IActionResult AddContentType()
		{
			vm.ContentTypeVM = _repo.ContentType();
			return PartialView("~/Views/Content/_AddContentType.cshtml", vm);
		}

		[HttpPost]
		public IActionResult CreateContentType(string cTitle)
		{
			var result = _repo.CreateContentType(cTitle);
			if (result == true)
			{
				return Json(new { statusCode = "200" });
			}
			else
			{
				return Json(new { statusCode = "300" });
			}
		}

		public IActionResult ContentCategory()
		{
			var res = _repo.GetAllCategories();
			vm.Categories = res;
			return View(vm);
		}

		public IActionResult AddCategory()
		{
			vm.ContentTypeVM = _repo.ContentType();
			return PartialView("/Views/Content/_PartialAddCategory.cshtml",vm);
		}

		[HttpPost]
		public IActionResult CreateCategory(string cTitle,string cType)
		{
			var res = _repo.CreateCategory(cTitle, cType);
			if (res)
			{
				return Json(new { statusCode = "200", Message = "Successfully Created" });
			}
			else
			{
				return Json(new { statusCode = "300", Message = "Unable to Create" });
			}
		}
		[HttpPost]
		[Route("/Content/UpdateContentCategory")]
		public IActionResult UpdateContentCategory(UpdateCategoryVM model)
		{
			var res = _repo.UpdateContentCategory(model);
			return Json(new { });
		}







		public IActionResult EditContentType(int Id)
		{
			vm.ContentType = _repo.GetContentTypebyId(Id);
			return PartialView("~/Views/Content/_EditContentType.cshtml", vm);
		}

		public IActionResult EditType(int Id, string cTitle)
		{
			var res = _repo.EditContentType(Id, cTitle);
			if (res)
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
