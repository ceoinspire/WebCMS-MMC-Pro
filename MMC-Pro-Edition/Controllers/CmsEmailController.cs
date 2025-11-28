using EmailHandler.Repository;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MailService = EmailHandler.Repository.MailService;

namespace MMC_Pro_Edition.Controllers
{
    [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin + "," + UserRoles.PowerUser + "," + UserRoles.Accounts)]

    public class CmsEmailController : Controller
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		private readonly CmsEmailRepository _email;
		PagesViewModel vm = new PagesViewModel();
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
			string htmlMessageforClient = $@"
<div class='container'>
    <div class='card shadow-sm mx-auto' style='max-width: 600px;'>
      <div class='card-header bg-info text-white text-center'>
        <h4 class='mb-0'>Inspire Nation</h4>
      </div>
      <div class='card-body text-center'>
        <h5 class='card-title text-success'>We've received your message!</h5>
        <p class='card-text text-muted'>
          Thank you for reaching out to us. Our team has successfully received your message and will get back to you shortly.
        </p>
        <hr>
        <p class='text-secondary mb-0'>
          In the meantime, feel free to browse our website for more information or updates.
        </p>
      </div>
      <div class='card-footer bg-light text-center small text-muted'>
        <p class='mb-1'>
          <strong>Note:</strong> This email was sent from <em>noreply@inspirenation.us</em>. Please do not reply.
        </p>
        <p class='mb-0'>
          For further assistance, contact us at 
          <a href='mailto:support@inspirenation.us' class='text-decoration-none text-info fw-semibold'>
            support@inspirenation.us
          </a>
        </p>
      </div>
    </div>
  </div>
";
            var e = _email.SingleEmail(1, email.EmailId);
			MailData m = new MailData();
			m.ToEmail = e.EmailSender;
			m.EmailBody = htmlMessageforClient;
			m.EmailSubject = e.EmailSubject;
			m.ToName = "Company";
			var res =_mailService.SendMail(m);
			SendToOwner(e);
			if (res)
			{
				_email.UpdateSendRecord(email.EmailId);
				return Json(new {statusCode="200",Message="Email Send Successfully" });
			}
				return Json(new {statusCode="300",Message="Unable to Send Email" });
		}
        public int SendToOwner([FromForm] CMSEmailVM e)
        {
            
            MailData m = new MailData();
            m.ToEmail = "ceo@inspirenation.us";
            m.EmailBody = e.EmailSubject + e.EmailBody;
            m.EmailSubject = "New WebRequest Received.";
            m.ToName = "Company";
            var res = _mailService.SendMail(m);
            
			return -1;
            //return Json(new { statusCode = "300", Message = "Unable to Send Email" });
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
