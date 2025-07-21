using Microsoft.AspNetCore.Identity;

namespace back_end.DTOs
{
    public class AccountDTO 
    {
        public string username {  get; set; }
        public string password { get; set; }
        public string hoten { get; set; }
        public int tuoi { get; set; }   
        public int gioitinh {get; set; }
        public string sdt { get; set; } 
        public string diachi { get; set; }  
        public string email { get; set; }
        public string loaitaikhoan { get; set; }
    }
}
