using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
            MaBrands = new HashSet<Brand>();
        }

        public string MaLoaiSanPham { get; set; }
        public string TenLoaiSanPham { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }

        public virtual ICollection<Brand> MaBrands { get; set; }
    }
}
