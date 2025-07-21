using AutoMapper;
using back_end.DataAccess;
using back_end.DTOs;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    public class CartController : BaseApiController
    {
        private  IRepository repo;
        private IMapper mapper;
        public CartController(IRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }


        //khi lấy sản phẩm trong giỏ hàng thì tìm kiếm theo personId 
        [HttpGet("{personId}")] //api/cart/{id}
        public async Task<ActionResult<Cart>> GetProductsInCart(string personId)
        {
            var productsInCart = await repo.GetProductsInCart(personId);
            var cartToReturn = this.mapper.Map<CartDTO>(productsInCart);
            return Ok(cartToReturn);
        }



        //[HttpPost("[action]/{cartId}")] // api/cart/updateCart/{}
        //public async Task<ActionResult> UpdateCart(CartSanPhamDTO cartSanPhamDTO, string cartId)
        //{
        //    CartSanPham newCartsanPham = new CartSanPham
        //    {
        //        MaCart = cartId,

        //    };
        //}

        [HttpDelete("[action]/{cartId}/{maSanPham}")]
        public async Task<ActionResult> DeleteProduct(string cartId,string maSanPham)
        {
            var cart = await repo.DeleteProductInCartAsync(cartId, maSanPham);
            if (cart == null)
            {
                return BadRequest("Some thing went wrong (có thể do cartId hoặc maSanPham)");
            }
            var cartToReturn = this.mapper.Map<CartDTO>(cart);
            return Ok(cartToReturn);

        }

        [HttpPut("[action]/{cartId}/{maSanPham}/{quantity}")] //api/cart/ChangeQuanlityOfProdut/
        public async Task<ActionResult> ChangeQuanlityOfProdut(string cartId, string maSanPham,int quantity)
        {
            var cart = await repo.ChangeQuantityOfProductInCartAsync(cartId, maSanPham, quantity);

            if (cart == null)
            {
                return BadRequest("Some thing went wrong (có thể do cartId hoặc maSanPham)");
            }
            var cartToReturn = this.mapper.Map<CartDTO>(cart);
            return Ok(cartToReturn);
        }


        [HttpPost("[action]")] //api/cart/AddProductIntoCart/DTO
        public async Task<ActionResult> AddProductIntoCart(CartSanPhamDTO cartSanPhamDTO)
        {
            var cart = await repo.AddProductIntoCartAsync(cartSanPhamDTO);
            if (cart == null)
            {
                return BadRequest("Some thing went wrong (có thể do cartId hoặc maSanPham)");
            }
            var cartToReturn = this.mapper.Map<CartDTO>(cart);
            return Ok(cartToReturn);

        }

    }
}
