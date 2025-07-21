using back_end.DataAccess;
using back_end.DTOs;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    public class KhachHangController : BaseApiController
    {
        private IRepository repo;
        public KhachHangController(IRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]    //api/KhachHang/
        public async Task<IEnumerable<KhachHangDTO>> GetKhachHang()
        {
            var khachhangs = await repo.GetKhachHangsAsync();

            return khachhangs;
        }   
    }
}
