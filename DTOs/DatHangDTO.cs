using back_end.Models;

namespace back_end.DTOs
{
    public class DatHangDTO
    {
        public string MaDatHang { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public string PersonId { get; set; }

        public ICollection<DatHangSanPhamDTO> DatHangSanPhams { get; set; }
        public PersonDTO Person { get; set; }
    }
}
