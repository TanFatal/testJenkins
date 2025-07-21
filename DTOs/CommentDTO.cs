using back_end.Models;

namespace back_end.DTOs
{
    public class CommentDTO
    {
        public string MaComment { get; set; } 
        public string NoiDungComment { get; set; }
        public int Star { get; set; }
        public DateTime? NgayComment { get; set; }

    }
}
