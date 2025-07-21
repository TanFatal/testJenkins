using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class DatHang
    {
        public DatHang()
        {
            DatHangSanPhams = new HashSet<DatHangSanPham>();
            HoaDons = new HashSet<HoaDon>();
        }

        public string MaDatHang { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public string PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<DatHangSanPham> DatHangSanPhams { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
