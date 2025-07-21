namespace back_end.Helpers
{

    //đây là những tham số mặc định khi gửi httprequest 
    //bao gồm trang hiện tại (1)
    //số sản phầm trên 1 trang (10)
    //số sản phẩm tối da trên 1 trang (50)
    //những tham số này sẽ thay đổi tùy thuộc vào request được gửi đi
    //
    public class UserParams
    {
        private const int MaxPageSize = 50;//số lượng sp tối da trên 1 page
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 5; 

        public int PageSize
        {
            get => _pageSize; 
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string? Brand { get; set; } = null;

        public string? Category { get; set; } = null;
    }
}
