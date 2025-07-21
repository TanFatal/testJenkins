using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class Comment
    {
        public string MaComment { get; set; }
        public string NoiDungComment { get; set; }
        public int Star { get; set; }
        public DateTime? NgayComment { get; set; }
        public string PersonId { get; set; }
        public string MaSanPham { get; set; }

        public virtual SanPham MaSanPhamNavigation { get; set; }
        public virtual Person Person { get; set; }
    }
}
