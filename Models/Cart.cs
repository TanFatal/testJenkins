using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartSanPhams = new HashSet<CartSanPham>();
        }

        public string MaCart { get; set; }
        public string PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<CartSanPham> CartSanPhams { get; set; }
    }
}
