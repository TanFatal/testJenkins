using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class Person
    {
        public Person()
        {
            Carts = new HashSet<Cart>();
            Comments = new HashSet<Comment>();
            DatHangs = new HashSet<DatHang>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public string PersonId { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public int GioiTinh { get; set; }
        public string Cccd { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }

        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<DatHang> DatHangs { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
