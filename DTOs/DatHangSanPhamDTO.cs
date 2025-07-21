namespace back_end.DTOs
{
    public class DatHangSanPhamDTO
    {
        public string MaDatHang { get; set; }
        public string MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaTien { get; set; }
        public decimal? TongTien { get; set; }

        public ProductDTORutGon MaSanPhamNavigation { get; set; } 
    }
}
