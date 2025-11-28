using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;


namespace MMC_Pro_Edition.Controllers
{
	[Authorize(Roles = UserRoles.User + "," + UserRoles.Admin + "," + UserRoles.PowerUser + "," + UserRoles.Accounts)]
	public class FileManagerController : Controller
	{
		private readonly IWebHostEnvironment _environment;
		private readonly ContentRepository _repo;


		public FileManagerController(IWebHostEnvironment environment, ContentRepository repo)
		{
			_environment = environment;
			_repo = repo;
		}


		[HttpPost]
		public IActionResult UploadImage(FileUploadVM model)
		{
			if (model.File != null && model.File.Length > 0)
			{
				// Save the uploaded image and get its URL
				var imageUrl = SaveImageAndGetUrl(model.File);
				//return Content("No file selected for upload.");
				_repo.updateImagesource(int.Parse(model.ContentId), imageUrl);
				return new JsonResult(new { imageUrl });
			}

			return BadRequest();
		}
		[HttpPost]
		public IActionResult SaveLogoOne(FileUploadVM model)
		{
			if (model.File != null && model.File.Length > 0)
			{
				// Save the uploaded image and get its URL
				var imageUrl = SaveImageAndGetUrl(model.File);
				var b = _repo.UpdateLogoOne(int.Parse(model.ContentId), imageUrl);
				//var suc = new WebsiteSetupRepository(_config,_con,_dapper).UpdateLogo(imageUrl, int.Parse(model.ContentId));
				//return Content("No file selected for upload.");
				return new JsonResult(new { imageUrl });
			}

			return BadRequest();
		}
		[HttpPost]
		public IActionResult SaveLogoMain(FileUploadVM model)
		{
			if (model.File != null && model.File.Length > 0)
			{
				var imageUrl = SaveImageAndGetUrl(model.File);
				var b = _repo.UpdateMainLogo(int.Parse(model.ContentId), imageUrl);
				return new JsonResult(new { imageUrl });
			}
			return BadRequest();
		}
		[HttpPost]
		public IActionResult SaveFavIcon(FileUploadVM model)
		{
			if (model.File != null && model.File.Length > 0)
			{
				var imageUrl = SaveImageAndGetUrl(model.File);
				var b = _repo.FavIcon(int.Parse(model.ContentId), imageUrl);
				return new JsonResult(new { imageUrl });
			}
			return BadRequest();
		}
		public IActionResult UploadHeaderImage(FileUploadVM model)
		{
			if (model.File != null && model.File.Length > 0)
			{
				// Save the uploaded image and get its URL
				var imageUrl = SaveImageAndGetUrl(model.File);
				//return Content("No file selected for upload.");
				_repo.UpdateHeaderImage(int.Parse(model.ContentId), imageUrl);
				return new JsonResult(new { imageUrl });
			}

			return BadRequest();
		}
		public IActionResult UploadListPhoto(FileUploadVM model)
		{
			if (model.File != null && model.File.Length > 0)
			{
				// Save the uploaded image and get its URL
				var imageUrl = SaveImageAndGetUrl(model.File);
				//return Content("No file selected for upload.");
				var response = _repo.UpdatePhotoList(int.Parse(model.ContentId), imageUrl);
				return new JsonResult(new { statusCode = "200" });
			}

			return BadRequest();
		}
		public IActionResult RemoveListPhoto(int Id)
		{
			var res = _repo.ReomovePhotoFromList(Id);
			if (res)
			{
				return new JsonResult(new { statusCode = "200" });

			}
			else
			{
				return new JsonResult(new { statusCode = "300" });

			}

		}


		[HttpPost]
		public IActionResult Upload()
		{
			try
			{
				var file = Request.Form.Files[0];

				if (file.Length > 0)
				{
					var uploadDir = Path.Combine(_environment.WebRootPath, "uploads");

					if (!Directory.Exists(uploadDir))
					{
						Directory.CreateDirectory(uploadDir);
					}

					var fileName = Path.Combine(uploadDir, Path.GetFileName(file.FileName));

					using (var stream = new FileStream(fileName, FileMode.Create))
					{
						file.CopyTo(stream);
					}

					return Content("File uploaded successfully.");
				}
			}
			catch (Exception ex)
			{
				return Content("Error: " + ex.Message);
			}

			return Content("No file selected for upload.");
		}
	
		private string SaveImageAndGetUrl(IFormFile file)
		{
			// Check if the file is not null and has content
			if (file != null && file.Length > 0)
			{
				// Define a unique filename for the uploaded image (you can use a GUID or other techniques)
				var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

				// Define the directory where you want to save the uploaded images
				var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

				// Ensure the directory exists; create it if it doesn't
				if (!Directory.Exists(uploadsFolder))
				{
					Directory.CreateDirectory(uploadsFolder);
				}

				// Combine the directory and the unique filename to get the full path
				var filePath = Path.Combine(uploadsFolder, uniqueFileName);

				// Save the file to the specified path
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					file.CopyTo(stream);
				}

				// In this example, we assume the images are saved in a folder called "uploads" under the wwwroot directory
				// You can customize the path as needed for your application

				// Generate the URL to the saved image
				var imageUrl = "/uploads/" + uniqueFileName; // Adjust the path accordingly

				return imageUrl;
			}

			// If the file is not valid, return null or an empty string
			return null;
		}
	
	}

}
