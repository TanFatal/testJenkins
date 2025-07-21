using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs
{
    public class RegisterDTO
    {
        public string hoten { get; set; }   
        public int tuoi { get; set; }   
        public int gioitinh { get; set; }
        public string cccd { get; set; } = null;
        public string sdt { get; set; } 
        public string diachi { get; set; }
        public string email { get; set; } = null;

        [Required(ErrorMessage = "Bạn chưa nhập tài khoản")]
        public string username { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        public string password { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập xác nhận mật khẩu")]
        public string confirmpassword { get; set; }
    }
}
