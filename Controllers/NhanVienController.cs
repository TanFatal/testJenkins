using back_end.DataAccess;
using back_end.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace back_end.Controllers
{
    public class NhanVienController : BaseApiController
    {
        public IRepository repo;
        public NhanVienController(IRepository repo)
        {
            this.repo = repo;   
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVienDTO>>> GetNhanVien()
        {
            var nhanviens = await repo.GetNhanVienAsync();

            if(nhanviens == null)
            {
                return NoContent();
            }


            return Ok(nhanviens);

        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<VaiTroNhanVienDTO>>> GetVaiTros()
        {
            var vaitros = await repo.GetVaiTrosAsync();
            if(vaitros.Count() <= 0 )
            {
                return NoContent();
            }

            return Ok(vaitros); 

        }


        [HttpPost]
        public async Task<ActionResult<CreateNhanVienDTO>> AddNhanVien(CreateNhanVienDTO newnhanvienDTO)
        {
            var nhanvienDTO = await repo.AddNhanVienAsync(newnhanvienDTO);

            return Ok(newnhanvienDTO);
        }

        [HttpPut("[action]/{maNhanVien}")]
        public async Task<ActionResult<CreateNhanVienDTO>> UpdateNhanVien(CreateNhanVienDTO newnhanvienDTO,string maNhanVien)
        {
            var check = await repo.UpdateNhanVienAsync(newnhanvienDTO, maNhanVien);
            if(check == null)
            {
                return NoContent();
            }

            return Ok(newnhanvienDTO);  
        }
        
    }
}
