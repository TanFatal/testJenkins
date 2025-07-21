using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class NhanVien
    {
        public string MaNhanVien { get; set; }
        public DateTime? NgayDuocTuyen { get; set; }
        public string MaVaiTro { get; set; }

        public virtual Person MaNhanVienNavigation { get; set; }
        public virtual VaiTroNhanVien MaVaiTroNavigation { get; set; }
    }
}
