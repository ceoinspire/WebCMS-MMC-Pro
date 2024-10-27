
using MMC_Pro_Edition.Repository;

namespace MMC_Pro_Edition.Classes
{
	public class CronJobsRepository : BackgroundService
	{
		private readonly ILogger<CronJobsRepository> _logger;
		private readonly CmsEmailRepository _emailRepository;
		private Timer _timer;

		public CronJobsRepository(ILogger<CronJobsRepository> logger, CmsEmailRepository emailRepository)
		{
			_logger = logger;
			_emailRepository = emailRepository;
		}
		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_logger.LogInformation("Email Cron Job Service is starting.");

			// Set up the timer to trigger the SendNotSentEmail method every 10 minutes
			_timer = new Timer(SendEmailTask, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

			return Task.CompletedTask;
		}

		private void SendEmailTask(object state)
		{
			try
			{
				_logger.LogInformation("Running SendNotSentEmail at: {time}", DateTimeOffset.Now);
				_emailRepository.SendNotSentEmail(); // Call your email sending function
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while sending emails.");
			}
		}

		public override Task StopAsync(CancellationToken stoppingToken)
		{
			_logger.LogInformation("Email Cron Job Service is stopping.");

			_timer?.Change(Timeout.Infinite, 0);
			return base.StopAsync(stoppingToken);
		}

		public override void Dispose()
		{
			_timer?.Dispose();
			base.Dispose();
		}


	}
}
