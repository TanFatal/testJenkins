using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class CartSanPham
    {
        public string MaCart { get; set; }
        public string MaSanPham { get; set; }
        public int? SoLuongSp { get; set; }
        public decimal? GiaTien { get; set; }

        public virtual Cart MaCartNavigation { get; set; }
        public virtual SanPham MaSanPhamNavigation { get; set; }
    }
}
