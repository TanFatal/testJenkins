using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs
{
    public class ThacMacKhieuNaiDTO
    {
        public string hoten { get; set; }

        public string email { get; set; }

        public string sdt { get; set; }

        public string tieude { get; set; }
        public string noidung { get; set; } 
    }
}
