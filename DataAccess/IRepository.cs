using back_end.DTOs;
using back_end.Helpers;
using back_end.Models;

namespace back_end.DataAccess
{
    public interface IRepository
    {
        //Brand
        IEnumerable<Brand> GetBrands { get; }
        Task<Brand> PostBrandAsync(Brand newBrand);
        Task<bool> DeleteBrandAsync(string brandId);
        Task<Brand> UpdateBrandAync(Brand brand);


        //LoaiSanPham Category
        IEnumerable<LoaiSanPham> GetLoaiSanPhams { get; }


        //SanPham

        string CreateMaSanPham();

        Task<PagedList<ProductDTO>> GetProductsAsync(UserParams userParams); // get san pham

        Task<SanPham> GetProductByIdAsync(string productId); // get san pham by id

        Task<SanPham> UpdateProductAsync(SanPham product); //update san pham

        Task<bool> DeleteProductAsync(string productId); //xóa sản phẩm

        Task<bool> AddProductAsync(SanPham newProduct); // them san pham mới


        //Cart
        Task<Cart> GetCartByPersonIdAsync(string personId);
        string CreateMaCart();
        Task<Cart> CreateCartAsync(Cart newCart);
        Task<Cart> GetProductsInCart(string personId);
        Task<Cart> DeleteProductInCartAsync(string cartId, string maSanPham);
        Task<Cart> ChangeQuantityOfProductInCartAsync(string cartId, string maSanPham,int quatity);
        Task<Cart> AddProductIntoCartAsync(CartSanPhamDTO cartSanPhamDTO);


        //Comment
        Task<string> CreateMaCommentAsync();
        Task<CommentDTO> AddCommentAsync(CommentDTO comment,string productId,string personId);

        //DatHang
        string CreateMaDatHang();
        Task<DatHangDTO> AddDatHangAsync(string personId);
        Task<IEnumerable<DatHangDTO>> GetDatHangByPersonIdsAsync(string personId);
        Task<IEnumerable<DatHangDTO>> GetDatHangsAsync();

        //DatHangSanPham


        //HoaDon


        //KhachHang
        string CreateMaKhachHang();
        bool AddKhachHang(string makhachhang);
        Task<IEnumerable<KhachHangDTO>> GetKhachHangsAsync();

        //LoaiTaiKhoan


        //MauSacSanPham


        //NhanVien
        string CreateMaNhanVien();
        Task<IEnumerable<NhanVienDTO>> GetNhanVienAsync();
        Task<CreateNhanVienDTO> AddNhanVienAsync(CreateNhanVienDTO thongTinNewNhanVien);
        Task<CreateNhanVienDTO> UpdateNhanVienAsync(CreateNhanVienDTO updateNhanVien,string newnhanvienDTO);
        
        //Person    
        IEnumerable<Person> GetUsers { get; }
        Task<PersonDTO> getUserByIdAsync(string id);
        Task<Person> UpdatePersonAsync(PersonDTO personDTO,string id);

        //TaiKhoan
        string CreateMaTaiKhoan();
        bool CreateAccount(TaiKhoan newTaiKhoan);
        bool CheckTaiKhoanExist(LoginDTO login);
        TaiKhoan CheckTaiKhoanVaMatKhauExist(LoginDTO login);

        Task<IEnumerable<AccountDTO>> GetAccountsAync();

        Task<AccountDTO> GetAccountByUserNameAync(string username);


        //ThacMacKhieuNai
        string CreateMaKhieuNai();
        Task<IEnumerable<ThacMacKhieuNai>> GetKhieuNaiAsync();

        Task<bool> PostKhieuNaiAsync(ThacMacKhieuNai thongtin);

        Task<bool> DeleteThacMacKhieuNaiAsync(string id);




        //TinhTrangSanPham
        Task<IEnumerable<TinhTrangSanPhamDTO>> GetTinhTrangSanPhamAsync();

        //VaiTroNhanVien
        Task<IEnumerable<VaiTroNhanVienDTO>> GetVaiTrosAsync();

        //Voucher


    }
}
