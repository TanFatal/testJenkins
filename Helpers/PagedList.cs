using Microsoft.EntityFrameworkCore;

namespace back_end.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items,int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double )pageSize); // tống số trang = tống số sp / số sp trên 1 trang
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }

        public int CurrentPage { get; set; }    //trang hiện tại
        public int TotalPages { get; set; }  // tổng số trang
        public int PageSize { get; set; }  //số sp trên 1 trang
        public int TotalCount { get; set; }  // tổng số sản phẩm





        //đây là hàm staic nên nó chỉ thuộc về class không thuộc về instance nên nó không liên quan gì code ở trên 
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source
            ,int pageNumber,int pageSize)
        {
            var count = await source.CountAsync(); //đếm xem source có bao nhiêu sản phẩm

            //tính toán bỏ bảo nhiều sản phẩm và lấy bảo nhiều sản phậm tại pageNumber
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            //cuối cùng trả về kiểu PagedList (tức là trả về hàm khởi tạo ở trên)
            //=> các thuộc tính ở trên nhận được giá trị
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
