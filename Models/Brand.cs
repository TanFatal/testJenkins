using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class Brand
    {
        public Brand()
        {
            SanPhams = new HashSet<SanPham>();
            MaLoaiSanPhams = new HashSet<LoaiSanPham>();
        }

        public string MaBrand { get; set; }
        public string TenBrand { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }

        public virtual ICollection<LoaiSanPham> MaLoaiSanPhams { get; set; }
    }
}
