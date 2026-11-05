using Microsoft.AspNetCore.Mvc;

namespace ITTalents.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("/admin")]
    [Route("/admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
