using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using Quartz;

namespace MMC_Pro_Edition.Classes
{
	public class LoggingCronJob : IJob
	{
		private readonly ILogger<LoggingCronJob> _logger;
		private readonly CmsEmailRepository _repo;
		private readonly IConfiguration _config;
		private readonly Onedb _onedb;
        public LoggingCronJob(ILogger<LoggingCronJob> logger,IConfiguration config,Onedb onedb)
        {
            _logger= logger;
			_config = config;
			_onedb = onedb;
			_repo = new CmsEmailRepository(_config,_onedb);
        }
        public Task Execute(IJobExecutionContext context)
		{
			_repo.SendNotSentEmail();
			//_logger.LogInformation("{UtcNow}",DateTime.UtcNow);
			return Task.CompletedTask;
		}
	}
}
