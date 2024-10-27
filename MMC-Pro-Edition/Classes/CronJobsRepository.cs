
using MMC_Pro_Edition.Repository;
using Quartz;

namespace MMC_Pro_Edition.Classes
{
	public static class CronJobsRepository
	{


		public static void AddInfrastructure(this IServiceCollection services)
		{
			services.AddQuartz(options =>
			{
				var jobkey= JobKey.Create(nameof(LoggingCronJob));
				options.AddJob<LoggingCronJob>(jobkey)
				.AddTrigger(trigger => trigger.ForJob(jobkey)
				.WithSimpleSchedule(schedule => schedule.WithIntervalInMinutes(5).RepeatForever())
				);
			});
			services.AddQuartzHostedService(options =>
			{
				options.WaitForJobsToComplete = true;
			});
		}

	}
}
