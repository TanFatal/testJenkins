using back_end.DataAccess;
using back_end.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    public class DatHangController : BaseApiController
    {
        private IRepository repo;
        public DatHangController(IRepository repo)
        {
            this.repo = repo;
        }




        [HttpGet("[action]/{personId}")]  //api/dathang/AddDatHang/{}
        public async Task<ActionResult<DatHangDTO>> AddDatHang(string personId)
        {
            var datHangDTO = await repo.AddDatHangAsync(personId);

            if (datHangDTO == null)
            {
                return NotFound("Bạn đưa đặt sản phẩm trong giỏ hàng");
            }

            return Ok(datHangDTO);
        }


        [HttpGet("[action]/{personId}")]  //api/dathang/GetDatHangs/{}
        public async Task<ActionResult<IEnumerable<DatHangDTO>>> GetDatHangs(string personId)
        {
            var dathangsDto = await repo.GetDatHangByPersonIdsAsync(personId);
            if(dathangsDto == null)
            {
                return NoContent();
            }


            return Ok(dathangsDto); 

        }


        [HttpGet]  //api/dathang/GetDatHangs
        public async Task<ActionResult<IEnumerable<DatHangDTO>>> GetDatHangsAll()
        {
            var dathangsDto = await repo.GetDatHangsAsync();
            if (dathangsDto == null)
            {
                return NoContent();
            }

            return Ok(dathangsDto);

        }
    }
}
