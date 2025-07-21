using back_end.DataAccess;
using back_end.DTOs;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private IRepository repo;
        public BrandController(IRepository repo)
        {
            this.repo = repo;
        }


        [HttpGet] //api/brands
        public IEnumerable<Brand> brands()
        {
            return repo.GetBrands;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<BrandDTO>> PostBrand(BrandDTO brandDTO)
        {
            Brand newBrand = new Brand
            { 
                MaBrand = brandDTO.maBrand,
                TenBrand = brandDTO.tenBrand,
            };
            var check = await repo.PostBrandAsync(newBrand);
            if (check == null)
            {
                return BadRequest("Lỗi có thể trùng mã brand");
            }
            return Ok(newBrand);

        }


        [HttpDelete("[action]/{brandId}")]
        public async Task<ActionResult> DeleteBrand(string brandId)
        {
            var check = await repo.DeleteBrandAsync(brandId);
            if(check)
            {
                return Ok("Xóa brand thành công");
            }
            return BadRequest("Xóa thất bại có thể do maBrand");
        }

        [HttpPut("[action]/{brandId}")]
        public async Task<ActionResult<BrandDTO>> UpdateBrand(BrandDTO updateBrandDTO, string brandId)
        {
            Brand newBrand = new Brand
            {
                MaBrand = brandId,
                TenBrand = updateBrandDTO.tenBrand
            };
            var check = await repo.UpdateBrandAync(newBrand);

            if(check == null)
            {
                return BadRequest("Lỗi có thể do ma brand");
            }

            return Ok(updateBrandDTO);

        }
    }
}
