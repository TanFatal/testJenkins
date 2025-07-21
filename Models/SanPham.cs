using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            CartSanPhams = new HashSet<CartSanPham>();
            Comments = new HashSet<Comment>();
            DatHangSanPhams = new HashSet<DatHangSanPham>();
            MaMauSacs = new HashSet<MauSacSanPham>();
        }

        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal? GiaSanPham { get; set; }
        public string MoTaSanPham { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnhSanPham { get; set; }
        public string MaTinhTrang { get; set; }
        public string MaBrand { get; set; }
        public string MaLoaiSanPham { get; set; }

        public virtual Brand MaBrandNavigation { get; set; }
        public virtual LoaiSanPham MaLoaiSanPhamNavigation { get; set; }
        public virtual TinhTrangSanPham MaTinhTrangNavigation { get; set; }
        public virtual ICollection<CartSanPham> CartSanPhams { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<DatHangSanPham> DatHangSanPhams { get; set; }

        public virtual ICollection<MauSacSanPham> MaMauSacs { get; set; }
    }
}
