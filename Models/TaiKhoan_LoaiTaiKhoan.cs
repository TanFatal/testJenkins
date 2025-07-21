using Microsoft.AspNetCore.Identity;

namespace back_end.Models
{
    public class TaiKhoan_LoaiTaiKhoan : IdentityUserRole<string>
    {
        public TaiKhoan TaiKhoan { get; set; }  
        public LoaiTaiKhoan LoaiTaiKhoan { get; set; }
    }
}
