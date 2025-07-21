using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Bạn cần phải nhập tài khoản")]
        public string username {  get; set; }

        [Required(ErrorMessage = "Bạn cần phải nhập mật khẩu")]
        public string password { get; set; }

       
    }
}
