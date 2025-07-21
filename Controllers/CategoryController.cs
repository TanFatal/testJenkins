using back_end.DataAccess;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {

        private IRepository repo;
        public CategoryController(IRepository repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        public IEnumerable<LoaiSanPham> getCategories()
        {
            return repo.GetLoaiSanPhams;
        }
    }
}
