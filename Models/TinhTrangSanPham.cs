using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class TinhTrangSanPham
    {
        public TinhTrangSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public string MaTinhTrang { get; set; }
        public string TenTinhTrang { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
