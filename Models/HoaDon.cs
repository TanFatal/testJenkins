using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class HoaDon
    {
        public string MaHoaDon { get; set; }
        public DateTime? NgayIn { get; set; }
        public decimal? TongTien { get; set; }
        public string MaDatHang { get; set; }

        public virtual DatHang MaDatHangNavigation { get; set; }
    }
}
