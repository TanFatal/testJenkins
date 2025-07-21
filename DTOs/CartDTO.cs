using back_end.Models;

namespace back_end.DTOs
{
    public class CartDTO
    {
        public string maCart { get; set; }
        public string personId { get; set; }
        public  ICollection<CartSanPhamDTO> cartSanPhams { get; set; }
    }
}
