using back_end.DataAccess;
using back_end.DTOs;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{

    public class KhieuNaiController : BaseApiController
    {
        private IRepository repo;

        public KhieuNaiController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet] //api
        public async Task<ActionResult<ThacMacKhieuNai>> GetKhieuNais()
        {
            var khieunais = await repo.GetKhieuNaiAsync();
            if (khieunais == null)
            {
                return NoContent();
            }

            return Ok(khieunais);
        }

        [HttpPost("postkieunai")] // api/khieunai/postkieunai
        public async Task<ActionResult<ThacMacKhieuNai>> PostKhieuNai(ThacMacKhieuNaiDTO thacmackhieunaiDTO)
        {
            if(thacmackhieunaiDTO.hoten == null || thacmackhieunaiDTO.hoten.Trim() == "")
            {
                return BadRequest("Vui lòng nhập họ tên");
            }

            if(thacmackhieunaiDTO.email == null || thacmackhieunaiDTO.email.Trim() == "")
            {
                return BadRequest("Vui lòng nhập email");
            }

            if(thacmackhieunaiDTO.sdt == null || thacmackhieunaiDTO.sdt.Trim() == "")
            {
                return BadRequest("Vui lòng nhập sđt");
            }

            if(thacmackhieunaiDTO.tieude == null || thacmackhieunaiDTO.tieude.Trim() == "")
            {
                return BadRequest("Vui lòng nhập tiêu đề");

            }

            if (thacmackhieunaiDTO.noidung == null || thacmackhieunaiDTO.noidung.Trim() == "")
            {
                return BadRequest("Vui lòng nhập nội dung");
            }

            ThacMacKhieuNai newThacMacKhieuNai = new ThacMacKhieuNai
            {
                MaKhieuNai = repo.CreateMaKhieuNai(),
                HoTen = thacmackhieunaiDTO.hoten,
                Email = thacmackhieunaiDTO.email,
                Sdt = thacmackhieunaiDTO.sdt,
                TieuDe = thacmackhieunaiDTO.tieude,
                NoiDung = thacmackhieunaiDTO.noidung,
                NgayKieuNai = DateTime.Now
            };
            bool check = await repo.PostKhieuNaiAsync(newThacMacKhieuNai);

            if(check)
            {
                return Ok(newThacMacKhieuNai);
            }

            return BadRequest("Có lỗi gì rồi !!!");
        }


        [HttpDelete("deletekhieunai/{id}")] //api/khieunai/deletekhieunai
        public async Task<ActionResult<string>> DeleteKhieuNai(string id)
        {
            var check = await repo.DeleteThacMacKhieuNaiAsync(id);
            if(check )
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
