using back_end.Models;

namespace back_end.DTOs
{
    public class KhachHangDTO
    {
        public string MaKhachHang { get; set; }

        public virtual PersonDTO MaKhachHangNavigation { get; set; }
    }
}
