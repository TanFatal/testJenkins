using back_end.Models;

namespace back_end.DTOs
{
    public class ProductDTO
    {
        public string masanpham { get; set; }
        public string tensanpham { get; set; }
        public decimal giasanpham { get; set; }
        public string motasanpham { get; set; }
        public int soluong { get; set; }
        public string hinhanhsanpham { get; set; }
        public string matinhtrang { get; set; } 
        public string mabrand {  get; set; }
        public string maloaisanpham { get; set; }
        public TinhTrangSanPhamDTO MaTinhTrangNavigation { get; set; }
        public BrandDTO MaBrandNavigation { get; set; } 
        public LoaiSanPhamDTO MaLoaiSanPhamNavigation { get; set; }
        public ICollection<CommentDTO> comments { get; set; }

    }
}
