using Microsoft.AspNetCore.Mvc;

namespace MMC_Pro_Edition.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Test()
        {
            return View();
        }
    }
}
