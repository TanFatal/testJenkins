using AutoMapper;
using back_end.DTOs;
using back_end.Models;

namespace back_end.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        { 
            CreateMap<CartSanPham,CartSanPhamDTO>();
            CreateMap<Cart,CartDTO>();
            CreateMap<SanPham,ProductDTO>();
            CreateMap<Comment,CommentDTO>();
            CreateMap<LoaiSanPham, LoaiSanPhamDTO>();
            CreateMap<Brand,BrandDTO>();
            CreateMap<TinhTrangSanPham, TinhTrangSanPhamDTO>();
            CreateMap<DatHang,DatHangDTO>();
            CreateMap<DatHangSanPham, DatHangSanPhamDTO>();
            CreateMap<SanPham, ProductDTORutGon>();
            CreateMap<TinhTrangSanPham, TinhTrangSanPhamDTO>();
            CreateMap<Person, PersonDTO>(); 
            CreateMap<NhanVien,NhanVienDTO>();
            CreateMap<VaiTroNhanVien, VaiTroNhanVienDTO>();
            CreateMap<TaiKhoan, AccountDTORutGon>();
            CreateMap<KhachHang,KhachHangDTO>();

        }
    }
}
