namespace MMC_Pro_Edition.Repository
{
	public class FileRepository
	{
		public string SaveImageMethod(IFormFile file)
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
