using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class TaiKhoan 
    {
        public string MaTaiKhoan { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PersonId { get; set; }
        public string MaLoaiTaiKhoan { get; set; }

        public virtual LoaiTaiKhoan MaLoaiTaiKhoanNavigation { get; set; }


        public virtual Person Person { get; set; }
    }
}
