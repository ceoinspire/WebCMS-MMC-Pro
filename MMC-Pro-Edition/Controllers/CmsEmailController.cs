using EmailHandler.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using MMC_Pro_Edition.Areas.Market.Repository;
using MMC_Pro_Edition.Areas.Market.ViewModels;
using MMC_Pro_Edition.Classes;
using MMC_Pro_Edition.Models;
using MMC_Pro_Edition.Repository;
using MMC_Pro_Edition.ViewModel;
using System.Drawing.Printing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MMC_Pro_Edition.Controllers
{
	public class CmsEmailController : Controller
	{
		private readonly IConfiguration _config;
		private readonly Onedb _con;
		private readonly DapperContext _dapper;
		//private readonly ContentRepository _conRepo;
		private readonly CmsEmailRepository _email;
		PagesViewModel vm = new PagesViewModel();

		private readonly IServiceProvider _serviceProvider;
		public CmsEmailController(IConfiguration config, Onedb con, DapperContext dapper)
		{
			_config = config;
			_con = con;
			_dapper = new DapperContext(_config);
			_email = new CmsEmailRepository(_config, _con);
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



		public IActionResult SendEmail()
		{
			EmailSender emailSender = new EmailSender(
		  smtpServer: "smtp.example.com",
		  smtpPort: 587,
		  smtpUser: "your-email@example.com",
		  smtpPassword: "your-email-password"
		  );
			emailSender.SendEmail(
		   fromAddress: "your-email@example.com",  
		   toAddress: "recipient-email@example.com",  
		   subject: "Test Email",                    
		   body: "This is a test email sent from C#." 
	   );
			return Json(new { });
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
