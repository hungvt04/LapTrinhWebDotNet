using ITTalents.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITTalents.Models.ProductModels;

namespace ITTalents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QlbanVaLiContext context = new QlbanVaLiContext();

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {


            var listSP = (from p in context.TDanhMucSps
                          select new Product
                          {
                              MaSp = p.MaSp,
                              TenSp = p.TenSp,
                              MaLoai = p.MaLoai,
                              AnhDaiDien = p.AnhDaiDien,
                              GiaNhoNhat = p.GiaNhoNhat
                          }).ToList();

            //return context.TDanhMucSps.ToList();

            return listSP;
        }


        [HttpGet("{maLoai}")]
        public IEnumerable<Product> GetAllProductsByLoai(string maLoai)
        {


            var listSP = (from p in context.TDanhMucSps where p.MaLoai == maLoai
                          select new Product
                          {
                              MaSp = p.MaSp,
                              TenSp = p.TenSp,
                              MaLoai = p.MaLoai,
                              AnhDaiDien = p.AnhDaiDien,
                              GiaNhoNhat = p.GiaNhoNhat
                          }).ToList();

            //return context.TDanhMucSps.ToList();

            return listSP;
        }


    }
}
