using System.Text.RegularExpressions;

namespace MMC_Pro_Edition.Repository
{
	public class HelperMethods
	{
		Random random = new Random(5);
		public string CreateSlug(string value)
		{
			var row = value.Replace(' ', '-');
			var sanitized = Regex.Replace(row, "[^a-zA-Z-]", string.Empty);
			string result = sanitized + "-" + random.Next(1000, 10000);
			return result;
		}
	}
}
