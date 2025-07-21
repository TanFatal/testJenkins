namespace back_end.DTOs
{
    public class PersonDTO
    {
        public string hoten { get; set; }
        public int tuoi { get; set; }   
        public int gioitinh { get; set; }
        public string sdt { get; set; }
        public string diachi { get; set; }
        public string email { get; set; }   
        public IEnumerable<AccountDTORutGon> TaiKhoans { get; set; }
    }
}
