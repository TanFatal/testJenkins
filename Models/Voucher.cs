using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class Voucher
    {
        public string VoucherId { get; set; }
        public string MaVoucher { get; set; }
        public DateTime? NgayPhatHanh { get; set; }
        public DateTime? NgayHetHang { get; set; }
    }
}
