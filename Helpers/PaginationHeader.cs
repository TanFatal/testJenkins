namespace back_end.Helpers
{
    public class PaginationHeader
    {
        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages, string brand, string category)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
            Brand = brand;
            Category = category;
        }



        public int CurrentPage { get; set; }    
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public string? Brand { get; set; } = null;
        public string? Category { get; set; } = null;
    }
}
