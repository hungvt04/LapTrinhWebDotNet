using ITTalents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ITTalents.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("/admin")]
    [Route("/admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            //var listSP = db.TDanhMucSps.ToList();
            int pageSize = 10;
            int pageNumber = page == null || page < 1 ? 1 : page.Value;
            var listSP = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);

            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(listSP, pageNumber, pageSize);


            return View(list);
        }
    }
}
