using System.Text.RegularExpressions;

namespace MMC_Pro_Edition.Repository
{
	public class HelperMethods
	{
        private readonly Random random = new Random(); 
        public string CreateSlug(string value)
        {
			if (!string.IsNullOrEmpty(value))
			{
				try
				{
					var row = value.Replace(' ', '-').ToLower();
					var sanitized = Regex.Replace(row, "[^a-z0-9-]", string.Empty);
					string result = sanitized + "-" + random.Next(1000, 10000);
					return result;
				}
				catch (Exception)	
				{

					throw;
				}
			}
			else
			{
				return "";
			}
		
         
        }
    }
}
