using back_end.Models;

namespace back_end.DTOs
{
    public class NhanVienDTO
    {
        public string MaNhanVien { get; set; }
        public DateTime? NgayDuocTuyen { get; set; }
        public string MaVaiTro { get; set; }

        public virtual PersonDTO MaNhanVienNavigation { get; set; }
        public virtual VaiTroNhanVienDTO MaVaiTroNavigation { get; set; }
    }
}
