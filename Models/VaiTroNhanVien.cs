using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class VaiTroNhanVien
    {
        public VaiTroNhanVien()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
