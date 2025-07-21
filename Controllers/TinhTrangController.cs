using AutoMapper;
using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    public class TinhTrangController : BaseApiController
    {
        private IRepository repo;
        private IMapper mapper;

        public TinhTrangController(IRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.mapper = mapper;
            this.repo = repo;
        }


        [HttpGet]  //api /tinhtrang
        public async Task<ActionResult<TinhTrangSanPham>> GetTinhTrangs()
        {
            var tinhtrangs = await repo.GetTinhTrangSanPhamAsync();
            return Ok(tinhtrangs);

        }
    }
}
