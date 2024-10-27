using EmailHandler.Repository;
using MailKit;
using Microsoft.AspNetCore.Mvc;


using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MailService = EmailHandler.Repository.MailService;

namespace MMC_Pro_Edition.Controllers
{
	public class CmsEmailController : Controller
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		private readonly CmsEmailRepository _email;
		PagesViewModel vm = new PagesViewModel();
		private readonly IServiceProvider _serviceProvider;
		private readonly MailService _mailService;
		public CmsEmailController(IConfiguration config, Onedb con, DapperContext dapper, EmailHandler.Repository.MailService mailService)
		{
			_config = config;
			_con = con;
			_dapper = new DapperContext(_config);
			_email = new CmsEmailRepository(_config, _con);
			_mailService = mailService;
		}

		[Route("/cmsemails/inbox")]
		public IActionResult GetAllEmails(int pageNumber = 1, string searchQuery = "", int pageSize = 5, string orderBy = "EmailId", bool ascending = false)
		{
			//var res = _email.Emails(PagesViewModel.WebsiteId, pageNumber, searchQuery, pageSize, orderBy, ascending);
			//vm.DtoEmails = res;
			return View(vm);
		}
		public IActionResult PartialEmails(int pageNumber = 1, string searchQuery = "", int pageSize = 5, string orderBy = "EmailId", bool ascending = false)
		{
			var res = _email.Emails(PagesViewModel.WebsiteId, pageNumber, searchQuery, pageSize, orderBy, ascending);
			vm.DtoEmails = res;
			int totalPages = (int)Math.Ceiling((double)res.EmailCount / pageSize);
			res.TotalPages = totalPages;
			return Json(new { res });
		}


		[HttpPost]
		public IActionResult SendEmail([FromForm]CMSEmailVM email)
		{
            var e = _email.SingleEmail(1, email.EmailId);
			MailData m = new MailData();
			m.ToEmail = e.EmailSender;
			m.EmailBody = e.EmailBody;
			m.EmailSubject = e.EmailSubject;
			m.ToName = "Company";
			var res =_mailService.SendMail(m);
			if (res)
			{
				_email.UpdateSendRecord(email.EmailId);
				return Json(new {statusCode="200",Message="Email Send Successfully" });
			}
				return Json(new {statusCode="300",Message="Unable to Send Email" });
		}














		[Route("cmsemail/inbox/folder/{Id}")]
		public IActionResult CmsEmailReadMail(int Id)
		{
			var res = _email.SingleEmail(1, Id);
			vm.Email = res;
			return View(vm);
		}

		public IActionResult DeleteEmails(DTOCMSEmail model)
		{
			var res = _email.RemoveEmails(model);
			if (res)
			{
				return Json(new { statusCode = "200" });
			}
			else
			{
				return Json(new { statusCode = "300" });
			}
		}
	}
}
