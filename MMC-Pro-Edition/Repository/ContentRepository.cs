using Dapper;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
		public List<ContentVM> GetContents(int WebsiteId)
		{
			return _con.Content.Include("ContentType").Where(x => x.ParentId == null && x.WebSiteId == WebsiteId).Select(x => new ContentVM
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
		public List<ContentVM> GetContents(int WebsiteId,int UserId)
		{
			return _con.Content.Include("ContentType").Where(x => x.ParentId == null && x.WebSiteId == WebsiteId &&x.LoginUserId==UserId).Select(x => new ContentVM
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
				MetaKeyword = x.MetaKeyword,
				Date = x.Date, Note=x.Note,VideoLink=x.VideoLink,OverView=x.OverView,Tagline=x.Tagline,
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
				,
				SharedCategory = _con.CmsContentSharedCategory.Where(w => w.ContentId == Id).Select(y => new CMSContentSharecCategoryVM
				{
					CategoryId = y.CategoryId,
					ContentId = y.ContentId,
					Id = y.Id
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
				Name = x.Name, ContentTypeSlug=x.TypeSlug
			}).ToList();
		}
		public List<ContentTypeVM> ContentTypebyContentId(int Id)
		{
			return _con.Content.Include("ContentType").Where(x => x.Id == Id).Select(w => new ContentTypeVM
			{
				Id = w.ContentType.Id,
				Name = w.ContentType.Name,
				ContentTypeSlug = w.ContentType.TypeSlug,
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

		public void AddLinkedContentItem(int linkitemId,int contentId)
		{
			int maxId = 0;
			
			if (_con.LinkedContentItems.Any())
			{
				maxId = _con.LinkedContentItems.Max(fm => fm.LinkedItemId) + 1;
			}
			else
			{
				maxId = 1;
			}
			LinkedContentItems lci = new LinkedContentItems();
			lci.LinkedItemId = maxId;
			lci.LinkedContentId = linkitemId;
			lci.ContentId = contentId;
			lci.Priority = 1;
			_con.LinkedContentItems.Add(lci);
			_con.SaveChanges();
		}
		public List<LinkedContent> LinkedItems(int ContentId)
		{
			using (var con =_dapper.CreateConnection())
			{
				string query = $"SELECT c.Id,c.Name,c.ContentSlug,lci.LinkedItemId FROM WEBCMS.LinkedContentItems lci " +
					$"JOIN WEBCMS.Content c on lci.LinkedContentId = c.Id where ContentId={ContentId}";
				var res = con.Query<LinkedContent>(query).ToList();
				return res;
			}
		}
		public bool RemoveLinkedItem(int Id)
		{
			var item = _con.LinkedContentItems.Where(x => x.LinkedItemId == Id).FirstOrDefault();
			_con.LinkedContentItems.Remove(item);
			_con.SaveChanges();
			return true;
		}
	
		#region CreateContent
		public string CreateContent(string cTitle, string cType, int UserId, int WebsiteId)
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
			c.MetaKeyword = cTitle;
			c.CreatedOn = DateTime.Now;
			c.OtherTitle = cTitle;
			c.LoginUserId = UserId;
			c.WebSiteId = WebsiteId;
			c.Date = DateTime.Now.Date;
			c.ModifiedOn = DateTime.Now;
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
		public bool CreateChildContent(string cTitle, string cType, string parentId, int UserId, int WebId)
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
			c.LoginUserId = UserId;
			c.WebSiteId = WebId;
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
				c.TypeSlug = cTitle.ToLower();

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
				content.ModifiedOn = DateTime.Now;
				content.Date = model.Date;
				content.MetaKeyword = model.MetaKeyword;
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
				content.Note = model.Note;
				content.Tagline = model.Tagline;
				content.OverView = model.OverView;
				content.VideoLink = model.VideoLink;
				content.ModifiedOn = DateTime.Now;
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
				Name = z.Name,
				ContentTypeSlug = z.TypeSlug
			}).FirstOrDefault();
		}
		public bool EditContentType(int Id, string cTitle, string typeSlug)
		{
			var content = _con.ContentType.Where(x => x.Id == Id).FirstOrDefault();
			if (content != null)
			{
				content.Name = cTitle;
				content.TypeSlug = typeSlug;
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
				content.ModifiedOn = DateTime.Now;
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
				content.ModifiedOn = DateTime.Now;
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
                int maxId = 0;
				if (_con.FileManager.Any())
				{
					maxId = _con.FileManager.Max(fm => fm.Id) + 1;

                }
				else
				{
					maxId = 1;
				}
                if (content != null)
				{
					var newFileManager = new FileManager
					{
						Url = Link,
						Caption = content.Name
					};
				

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
		public bool UpdateLogoOne(int Id, string Url)
		{
			var res = _con.Website.Where(x => x.WebsiteId == Id).FirstOrDefault();
			res.WebsiteLogoTwo = Url;
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
			{
				Id = x.Id,
				Name = x.Name,
				Slug = x.Slug
			  ,
				TypeName = x.Type.Name
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
				int maxId=0;
				if (_con.ContentCategory.Any())
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
				c.Slug = cTitle.ToLower();

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

		public ContentCategoryVM GetCategory(int Id)
		{
			using (var con = _dapper.CreateConnection())
			{
				string query = $"SELECT * FROM WebCms.ContentCategory where Id={Id}";
				var result = con.Query<ContentCategoryVM>(query).FirstOrDefault();
				return result;
			}
		}
		public bool EditContentCategory(ContentCategoryVM model)
		{
			using (var con = _dapper.CreateConnection())
			{
				con.Open();
				using (var transaction = con.BeginTransaction())
				{
					try
					{
						var parameters = new
						{
							Name = model.Name,
							Slug = model.Slug,
							Id = model.Id
						};
						string query = "UPDATE Webcms.ContentCategory SET Name = @Name, Slug = @Slug WHERE Id = @Id";
						int rowsAffected = con.Execute(query, parameters, transaction: transaction);
						if (rowsAffected > 0)
						{
							transaction.Commit();
							return true;
						}
						else
						{
							transaction.Rollback();
							return false;
						}
					}
					catch (Exception ex)
					{
						// Rollback the transaction in case of an error
						transaction.Rollback();
						throw new Exception("Error updating ContentCategory", ex);
					}
				}
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
				if (model.Category != null)
				{
					var con = _dapper.CreateConnection();

					List<CmsContentSharedCategory> csc = new List<CmsContentSharedCategory>();

					int maxId = 0;

					if (_con.CmsContentSharedCategory.Any())
					{
                       maxId= _con.CmsContentSharedCategory.Max(fm => fm.Id) + 1;
                    }
					else
					{
						maxId = 1;
					}
					

					foreach (var item in model.Category)
					{
						csc.Add(new CmsContentSharedCategory
						{
							Id = maxId,
							CategoryId = int.Parse(item),
							ContentId = model.ContentId,
							CreatedOn = DateTime.Now
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

		#region Reviews
		public List<ReviewVM> GetReviewsbyContent(int Id)
		{
			var reviews = _con.Reviews.Where(x => x.ContentId == Id).Select(y=>new ReviewVM
			{
				ReviewId = y.ReviewId,
				Rating = y.Rating,
				Comment = y.ReviewComment,
				IsPublished = y.IsPublished,
				CreatedOn = y.CreatedOn
			}).ToList();
			return reviews;
		}
		#endregion
	}
}
