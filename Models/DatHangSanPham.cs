using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class DatHangSanPham
    {
        public string MaDatHang { get; set; }
        public string MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaTien { get; set; }
        public decimal? TongTien { get; set; }

        public virtual DatHang MaDatHangNavigation { get; set; }
        public virtual SanPham MaSanPhamNavigation { get; set; }
    }
}
