using ITTalents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace ITTalents.Controllers
{
    public class HomeController : Controller
    {

        QlbanVaLiContext db = new QlbanVaLiContext();

        public IActionResult Index(int? page)
        {
            //var listSP = db.TDanhMucSps.ToList();
            int pageSize = 8;
            int pageNumber = page == null || page < 1 ? 1 : page.Value;
            var listSP = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listSP, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult SanPhamTheoLoai(String maLoai, int? page)
        {
            //List<TDanhMucSp> listSP = db.TDanhMucSps.Where
            //    (x => x.MaLoai == maLoai).OrderBy(x => x.TenSp).ToList();

            int pageSize = 8;
            int pageNumber = page == null || page < 1 ? 1 : page.Value;
            var listSP = db.TDanhMucSps.AsNoTracking().Where(x => x.MaLoai == maLoai).OrderBy(x => x.TenSp);
            PagedList <TDanhMucSp> sps = new PagedList<TDanhMucSp>(listSP, pageNumber, pageSize);
            ViewBag.maLoai = maLoai;
            return View(sps);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
