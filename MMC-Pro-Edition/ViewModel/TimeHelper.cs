namespace MMC_Pro_Edition.ViewModel
{
	public class TimeHelper
	{
		public static string GetGreeting()
		{
			DateTime now = DateTime.Now;
			int hour = now.Hour;

			if (hour >= 5 && hour < 12)
			{
				return "Good Morning";
			}
			else if (hour >= 12 && hour < 17)
			{
				return "Good Afternoon";
			}
			else if (hour >= 17 && hour < 21)
			{
				return "Good Evening";
			}
			else
			{
				return "It's Night Better Take Rest";
			}
		}
		public static string GetFormattedTimeSpan(DateTime createdOn)
		{
			var res = DateTime.Now - createdOn;

			if (res.TotalMinutes < 5)
			{
				return "Just Now";
			}
			else if (res.TotalMinutes < 60)
			{
				return $"{res.Minutes} minutes ago";
			}
			else if (res.TotalHours < 24)
			{
				return $"{res.Hours} hours ago";
			}
			else if (res.TotalDays < 7)
			{
				return $"{res.Days} days ago";
			}
			else
			{
				return createdOn.ToString("MMM dd, yyyy");
			}
		}
	}

}
