using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class MauSacSanPham
    {
        public MauSacSanPham()
        {
            MaSanPhams = new HashSet<SanPham>();
        }

        public string MaMauSac { get; set; }
        public string TenMauSac { get; set; }

        public virtual ICollection<SanPham> MaSanPhams { get; set; }
    }
}
