using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class ThacMacKhieuNai
    {
        public string MaKhieuNai { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayKieuNai { get; set; }
    }
}
