using Dapper;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.ViewModel;
using System.Drawing;

namespace MMC_Pro_Edition.Repository
{
	public class ContentRepository
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		private readonly HelperMethods _helper = new HelperMethods();
		public ContentRepository(IConfiguration config, Onedb con, DapperContext dapper)
		{
			_config = config;
			_con = con;
			_dapper = new DapperContext(_config);
		}


		#region GetContent
		//Get List of Content
		public List<ContentVM> GetContents()
		{
			return _con.Content.Include("ContentType").Where(x => x.ParentId == null).Select(x => new ContentVM
			{
				Id = x.Id,
				Name = x.Name,
				ContentSlug = x.ContentSlug,
				Thumbnail = x.Thumbnail,
				CreatedOn = x.CreatedOn,
				MetaTitle = x.MetaTitle,
				MetaDescription = x.MetaDescription,
				ContentTypeVM = _con.ContentType.Where(W => W.Id == x.ContentTypeId).Select(v => new ContentTypeVM
				{
					Id = v.Id,
					Name = v.Name
				}).FirstOrDefault()
			}).ToList();
		}
		public int ContentCount()
		{
			return _con.Content.Count();
		}
		//Get Content by Id
		public ContentVM GetContentbyId(int Id)
		{
			return _con.Content.Where(x => x.Id == Id).Select(x => new ContentVM
			{
				Id = x.Id,
				Name = x.Name,
				Icon = x.Icon,
				MetaTitle = x.MetaTitle,
				Priority = x.Priority,
				HeaderPhoto = x.HeaderPhoto,
				ContentSlug = x.ContentSlug,
				OtherShortDescription = x.OtherShortDescription,
				Description = x.Description,
				ImageSource = x.ImageSource,
				MetaDescription = x.MetaDescription,
				OtherDescription = x.OtherDescription,
				OtherTitle = x.OtherTitle,
				ShortDescription = x.ShortDescription,
				Thumbnail = x.Thumbnail
				, SharedCategory=_con.CmsContentSharedCategory.Where(w=>w.ContentId==Id).Select(y=>new CMSContentSharecCategoryVM
				{
					 CategoryId=y.CategoryId, ContentId=y.ContentId,Id=y.Id
				}).ToList(),
				PhotoList = _con.FileManager.Where(x => x.ContentId == Id).Select(w => new MediaManager
				{
					URL = w.Url,
					ContentId = w.ContentId,
					Caption = w.Caption,
					Id = w.Id
				}).ToList()
			}).FirstOrDefault();
		}

		#endregion
		#region GetContentType
		//Get list of ContentType
		public List<ContentTypeVM> ContentType()
		{
			return _con.ContentType.ToList().Select(x => new ContentTypeVM()
			{
				Id = x.Id,
				Name = x.Name,
			}).ToList();
		}
		public List<ContentTypeVM> ContentTypebyContentId(int Id)
		{
			return _con.Content.Include("ContentType").Where(x => x.Id == Id).Select(w => new ContentTypeVM
			{
				Id = w.ContentType.Id,
				Name = w.ContentType.Name
			}).ToList();

		}


		#endregion

		public bool RemoveContent(int Id)
		{
			var c = _con.Content.Where(x => x.Id == Id).FirstOrDefault();
			_con.Content.Remove(c);
			var res = _con.SaveChanges();
			if (res == 1)
			{
				return true;
			}
			else
			{
				return false;
			}

		}
		public List<ContentVM> GetChildContent(int Id)
		{
			return _con.Content.Include("ContentType").Where(x => x.ParentId == Id).Select(x => new ContentVM
			{
				Id = x.Id,
				Name = x.Name,
				ContentSlug = x.ContentSlug,
				Thumbnail = x.Thumbnail,
				CreatedOn = x.CreatedOn,
				MetaTitle = x.MetaTitle,
				MetaDescription = x.MetaDescription,
				ContentTypeVM = _con.ContentType.Where(W => W.Id == x.ContentTypeId).Select(v => new ContentTypeVM
				{
					Id = v.Id,
					Name = v.Name
				}).FirstOrDefault()
			}).ToList();
		}
		#region CreateContent
		public string CreateContent(string cTitle, string cType)
		{
			Content c = new Content();

			var counting = _con.Content.Count();
			if (counting == 0)
			{
				c.Id = 1;
			}
			else
			{
				int maxId = _con.Content.Max(fm => fm.Id) + 1;
				c.Id = maxId;
			}

			c.Name = cTitle;
			c.MetaTitle = cTitle;
			c.MetaDescription = cTitle;
			c.CreatedOn = DateTime.Now;
			c.OtherTitle = cTitle;

			c.ContentSlug = _helper.CreateSlug(cTitle);
			var contentType = _con.ContentType.Where(x => x.Id == int.Parse(cType)).FirstOrDefault();
			c.ContentType = contentType;
			_con.Content.Add(c);
			var res = _con.SaveChanges();
			if (res == 1)
			{
				return $"true,{c.Id.ToString()}";
			}
			else
			{
				return "false,2";
			}
		}
		public bool CreateChildContent(string cTitle, string cType, string parentId)
		{
			int maxId = _con.Content.Max(fm => fm.Id) + 1;

			Content c = new Content();
			c.Id = maxId;
			c.Name = cTitle;
			c.MetaTitle = cTitle;
			c.MetaDescription = cTitle;
			c.CreatedOn = DateTime.Now;
			c.OtherTitle = cTitle;
			c.ParentId = int.Parse(parentId);
			var row = cTitle.Split(' ');
			c.ContentSlug = cTitle;
			var contentType = _con.ContentType.Where(x => x.Id == int.Parse(cType)).FirstOrDefault();
			c.ContentType = contentType;
			_con.Content.Add(c);
			var res = _con.SaveChanges();
			if (res == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool CreateContentType(string cTitle)
		{
			var Ctype = _con.ContentType.Where(x => x.Name == cTitle).FirstOrDefault();
			if (Ctype == null)
			{
				int maxId;
				if (_con.ContentType.Any())
				{
					maxId = _con.ContentType.Max(fm => fm.Id) + 1;
				}
				else
				{
					// If there are no records in the table, set maxId to 1 or any initial value you prefer.
					maxId = 1;
				}
				ContentType c = new ContentType();
				c.Id = maxId;
				c.Name = cTitle;
				c.TypeSlug = _helper.CreateSlug(cTitle);

				_con.ContentType.Add(c);
				var res = _con.SaveChanges();
				if (res == 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}

		}



		#endregion
		#region UpdateContent
		//Update Content
		public bool UpdateBasicContent(ContentVM model)
		{
			try
			{
				var content = _con.Content.Where(x => x.Id == model.Id).FirstOrDefault();
				content.OtherTitle = model.OtherTitle;
				content.Name = model.Name;
				content.Priority = model.Priority;
				content.Icon = model.Icon;
				content.MetaTitle = model.MetaTitle;
				content.MetaDescription = model.MetaDescription;
				content.ContentSlug = model.ContentSlug;

				var resp = _con.SaveChanges();
				return true;
			}
			catch (Exception e)
			{

				return false;

			}
		}

		//Update Description Content
		public bool UpdateDescContent(ContentVM model)
		{
			try
			{
				var content = _con.Content.Where(x => x.Id == model.Id).FirstOrDefault();
				content.Description = model.Description;
				content.ShortDescription = model.ShortDescription;
				content.OtherDescription = model.OtherDescription;
				content.OtherShortDescription = model.OtherShortDescription;
				_con.SaveChanges();
				return true;
			}
			catch (Exception e)
			{

				return false;

			}
		}
		public ContentTypeVM GetContentTypebyId(int Id)
		{
			return _con.ContentType.Where(x => x.Id == Id).Select(z => new ContentTypeVM()
			{
				Id = z.Id,
				Name = z.Name
			}).FirstOrDefault();
		}
		public bool EditContentType(int Id, string cTitle)
		{
			var content = _con.ContentType.Where(x => x.Id == Id).FirstOrDefault();
			if (content != null)
			{
				content.Name = cTitle;
				var res = _con.SaveChanges();
				if (res == 1)
				{
					return true;

				}
			}
			return false;
		}
		#endregion


		#region ImagesSection
		public bool updateImagesource(int Id, string URL)
		{
			try
			{
				var content = _con.Content.Where(x => x.Id == Id).FirstOrDefault();
				content.ImageSource = URL;
				_con.SaveChanges();
				return true;
			}
			catch (Exception e)
			{

				return false;

			}
		}

		public bool UpdateHeaderImage(int Id, string URL)
		{
			try
			{
				var content = _con.Content.Where(x => x.Id == Id).FirstOrDefault();
				content.HeaderPhoto = URL;
				_con.SaveChanges();
				return true;
			}
			catch (Exception e)
			{

				return false;

			}
		}
		public bool UpdatePhotoList(int ContentId, string Link)
		{
			try
			{
				var content = _con.Content.Include(c => c.FileManager).FirstOrDefault(x => x.Id == ContentId);

				if (content != null)
				{
					var newFileManager = new FileManager
					{
						Url = Link,
						Caption = content.Name
					};
					int maxId = _con.FileManager.Max(fm => fm.Id) + 1;

					newFileManager.Id = maxId;
					content.FileManager.Add(newFileManager);

					_con.SaveChanges();
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				return false;
			}
		}
		public bool ReomovePhotoFromList(int ContentId)
		{
			var content = _con.FileManager.FirstOrDefault(x => x.Id == ContentId);
			if (content != null)
			{
				_con.FileManager.Remove(content);
				var response = _con.SaveChanges();
				var m = response;
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool UpdateLogoOne(int Id,string Url)
		{
			var res = _con.Website.Where(x => x.WebsiteId == Id).FirstOrDefault();
			res.WebsiteLogoTwo=Url;
			_con.SaveChanges();
			return true;
		}
		public bool UpdateMainLogo(int Id, string Url)
		{
			var res = _con.Website.Where(x => x.WebsiteId == Id).FirstOrDefault();
			res.WebsiteLogo = Url;
			_con.SaveChanges();
			return true;
		}
		public bool FavIcon(int Id, string Url)
		{
			var res = _con.Website.Where(x => x.WebsiteId == Id).FirstOrDefault();
			res.FavIcon = Url;
			_con.SaveChanges();
			return true;
		}
		#endregion
		#region Category
		public List<ContentCategoryVM> GetAllCategories()
		{
			return _con.ContentCategory.Select(x => new ContentCategoryVM
			{ Id=x.Id,
			Name=x.Name,
			 Slug=x.Slug

			}).ToList();
		}

		public List<ContentCategoryVM> GetAllCategoriesbyType(int Id)
		{
			var con = _dapper.CreateConnection();
			var query = $"select cc.Id,cc.Name,cc.Slug from WEBCMS.Content c join WEBCMS.ContentType ct on c.ContentTypeId=ct.Id join WEBCMS.ContentCategory cc on ct.Id=cc.TypeId where c.Id={Id}";
			var result = con.Query<ContentCategoryVM>(query).ToList();
			return result;
		}

		public bool CreateCategory(string cTitle, string cType)
		{
			var Ctype = _con.ContentCategory.Where(x => x.Name == cTitle).FirstOrDefault();
			if (Ctype == null)
			{
				int maxId;
				if (_con.ContentType.Any())
				{
					maxId = _con.ContentCategory.Max(fm => fm.Id) + 1;
				}
				else
				{
					maxId = 1;
				}
				ContentCategory c = new ContentCategory();
				c.Id = maxId;
				c.Name = cTitle;
				c.TypeId = int.Parse(cType);
				c.Slug = _helper.CreateSlug(cTitle);

				_con.ContentCategory.Add(c);
				var res = _con.SaveChanges();
				if (res == 1)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}

		}
		
		
		public bool UpdateContentCategory(UpdateCategoryVM model)
		{

			if (model != null)
			{
				var c = _con.CmsContentSharedCategory.Where(x => x.ContentId == model.ContentId).ToList();
				if (c != null)
				{
					_con.CmsContentSharedCategory.RemoveRange(c);
					_con.SaveChanges();
				}
				if (model.Category!=null)
				{
					var con = _dapper.CreateConnection();

					List<CmsContentSharedCategory> csc = new List<CmsContentSharedCategory>();
					int maxId = _con.ContentCategory.Max(fm => fm.Id) + 1;

					foreach (var item in model.Category)
					{
						csc.Add(new CmsContentSharedCategory
						{
							  Id=maxId,
							  CategoryId= int.Parse( item), ContentId=model.ContentId, CreatedOn=DateTime.Now
						});
						maxId++;
					}
					_con.CmsContentSharedCategory.AddRange(csc);
					_con.SaveChanges();
				}
			
			}

			return false;
		}
		
		
		
		
		
		
		#endregion


	}
}
