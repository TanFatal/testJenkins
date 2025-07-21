using AutoMapper;
using AutoMapper.QueryableExtensions;
using back_end.DTOs;
using back_end.Helpers;
using back_end.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.OpenApi.Validations;
using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace back_end.DataAccess
{
    public class Repository : RepositotyBaseFunction, IRepository
    {
        private EcommerceContext context;
        private readonly IMapper mapper;

        public Repository(EcommerceContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Brand

        public IEnumerable<Brand> GetBrands => context.Brands.Include(b => b.SanPhams).
            Select(b => new Brand { MaBrand = b.MaBrand, TenBrand = b.TenBrand, SanPhams = b.SanPhams });


        public async Task<Brand> PostBrandAsync(Brand newBrand)
        {
            var checkBrand = context.Brands.FirstOrDefault(b => b.MaBrand == newBrand.MaBrand);

            if (checkBrand != null)
            {
                return null;
            }

            context.Brands.Add(newBrand);
            await context.SaveChangesAsync();
            return newBrand;
        }
        public async Task<bool> DeleteBrandAsync(string brandId)
        {
            var checkBrand = context.Brands.FirstOrDefault(b => b.MaBrand == brandId);
            if (checkBrand == null)
            {
                return false;
            }

            context.Brands.Remove(checkBrand);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Brand> UpdateBrandAync(Brand brand)
        {
            var brandNeedToBeUpdated = context.Brands.FirstOrDefault(b => b.MaBrand == brand.MaBrand);
            if (brandNeedToBeUpdated == null)
            {
                return null;
            }

            brandNeedToBeUpdated.TenBrand = brand.TenBrand;
            context.Brands.Update(brandNeedToBeUpdated);
            await context.SaveChangesAsync();
            return brand;
        }


        //LoaiSanPham Category
        public IEnumerable<LoaiSanPham> GetLoaiSanPhams => context.LoaiSanPhams;


        //SanPham
        public string CreateMaSanPham()
        {
            List<string> masanphams = context.SanPhams.Select(sp => sp.MaSanPham).ToList();
            string lastID = base.funcGetLastIndex(masanphams, 0).ToString();
            return lastID;
        }

        public async Task<PagedList<ProductDTO>> GetProductsAsync(UserParams userParams)
        {

            var query = context.SanPhams
                .ProjectTo<ProductDTO>(this.mapper.ConfigurationProvider)
                .AsNoTracking();
            //do đã ProjectTo nên không cần include vì nó đã tự làm cho mình

            if (!String.IsNullOrEmpty(userParams.Category) && userParams.Category != "undefined")
            {
                query = query.Where(p => p.maloaisanpham == userParams.Category);
            }

            if (!String.IsNullOrEmpty(userParams.Brand) && userParams.Brand != "undefined")
            {
                query = query.Where(p => p.mabrand == userParams.Brand);
            }

            //kết quả trả về là 1 pagedList cho biết các sản phẩm trên trang hiện tại
            return await PagedList<ProductDTO>
                .CreateAsync(query, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<SanPham> GetProductByIdAsync(string id)
        {
            return await context.SanPhams.Where(sp => sp.MaSanPham == id)
                .Include(sp => sp.Comments)
                .Include(sp => sp.MaBrandNavigation)
                .Include(sp => sp.MaTinhTrangNavigation)
                .Include(sp => sp.MaTinhTrangNavigation)
                .Include(sp => sp.MaLoaiSanPhamNavigation)
                .FirstOrDefaultAsync();
        }

        public async Task<SanPham> UpdateProductAsync(SanPham newProduct)
        {
            var productNeedToBeUpdated = context.SanPhams.
                FirstOrDefault(sp => sp.MaSanPham == newProduct.MaSanPham);
            if (productNeedToBeUpdated == null)
            {
                return null;
            }
            productNeedToBeUpdated.TenSanPham = newProduct.TenSanPham;
            productNeedToBeUpdated.GiaSanPham = newProduct.GiaSanPham;
            productNeedToBeUpdated.MoTaSanPham = newProduct.MoTaSanPham;
            productNeedToBeUpdated.SoLuong = newProduct.SoLuong;
            productNeedToBeUpdated.HinhAnhSanPham = newProduct.HinhAnhSanPham;
            productNeedToBeUpdated.MaTinhTrang = newProduct.MaTinhTrang;
            productNeedToBeUpdated.MaBrand = newProduct.MaBrand;
            productNeedToBeUpdated.MaLoaiSanPham = newProduct.MaLoaiSanPham;
            context.SanPhams.Update(productNeedToBeUpdated);
            await context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<bool> DeleteProductAsync(string productId) //xóa sản phẩm
        {
            var product = context.SanPhams.FirstOrDefault(p => p.MaSanPham.ToLower() == productId.ToLower());
            if (product == null)
            {
                return false;
            }

            context.SanPhams.Remove(product);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddProductAsync(SanPham newProduct) //thêm sản phẩm
        {
            var check = context.SanPhams.FirstOrDefault(p => p.MaSanPham == newProduct.MaSanPham);
            if (check != null)
            {
                return false;
            }

            await context.SanPhams.AddAsync(newProduct);
            await context.SaveChangesAsync();
            return true;
        }



        //Cart
        public async Task<Cart> GetCartByPersonIdAsync(string personId)
        {
            var cart = await context.Carts.FirstOrDefaultAsync(c => c.PersonId == personId);
            if (cart == null)
            {
                return null;
            }

            return cart;
        }

        public string CreateMaCart()
        {
            List<string> makhachhangs = context.Carts.Select(c => c.MaCart).ToList();
            string lastID = "Cart" + base.funcGetLastIndex(makhachhangs, 4);
            return lastID;
        }
        public async Task<Cart> CreateCartAsync(Cart newCart)
        {
            Cart check = context.Carts.FirstOrDefault(c => c.MaCart.ToLower() == newCart.MaCart.ToLower());
            if (check != null)
            {
                return null;
            }

            context.Carts.Add(newCart);
            await context.SaveChangesAsync();
            return newCart;
        }
        public async Task<Cart> GetProductsInCart(string personId)
        {
            var productsInCart = await context.Carts
                .Where(c => c.PersonId == personId)
                .Include(c => c.CartSanPhams)
                .ThenInclude(c => c.MaSanPhamNavigation)
                .FirstOrDefaultAsync();
            return productsInCart;
        }


        public async Task<Cart> DeleteProductInCartAsync(string cartId, string maSanPham)
        {
            var deleteCartSanPham = context.CartSanPhams
                .Where(csp => csp.MaCart.ToLower() == cartId.ToLower()
                                             && csp.MaSanPham.ToLower() == maSanPham.ToLower())
                .Include(c => c.MaSanPhamNavigation).ToList();
            if (deleteCartSanPham.Count <= 0)
            {
                return null;
            }
            context.CartSanPhams.RemoveRange(deleteCartSanPham);

            await context.SaveChangesAsync();
            var cartToReturn = await context.Carts
                .Where(c => c.MaCart == cartId)
                .Include(c => c.CartSanPhams)
                .ThenInclude(c => c.MaSanPhamNavigation)
                .FirstOrDefaultAsync();

            return cartToReturn;
        }

        public async Task<Cart> ChangeQuantityOfProductInCartAsync(string cartId, string maSanPham, int quatity)
        {
            var changeQualityCartSanPham = await context.CartSanPhams
                .Where(csp => csp.MaCart.ToLower() == cartId.ToLower()
                                             && csp.MaSanPham.ToLower() == maSanPham.ToLower())
                .Include(c => c.MaSanPhamNavigation).FirstOrDefaultAsync();
            if (changeQualityCartSanPham == null)
            {
                return null;
            }
            changeQualityCartSanPham.SoLuongSp = quatity;
            context.CartSanPhams.Update(changeQualityCartSanPham);
            await context.SaveChangesAsync();
            var cartToReturn = await context.Carts
                .Where(c => c.MaCart == cartId)
                .Include(c => c.CartSanPhams)
                .ThenInclude(c => c.MaSanPhamNavigation)
                .FirstOrDefaultAsync();
            return cartToReturn;
        }

        public async Task<Cart> AddProductIntoCartAsync(CartSanPhamDTO cartSanPhamDTO)
        {
            var cart = await context.Carts
                .FirstOrDefaultAsync(c => c.MaCart.ToLower() == cartSanPhamDTO.cartId.ToLower());
            if (cart == null)
            {
                return null;
            }

            var checkSpCoTrongGiohang = await context.CartSanPhams
                .FirstOrDefaultAsync(csp => csp.MaCart.ToLower() == cartSanPhamDTO.cartId.ToLower()
                                                        && csp.MaSanPham.ToLower() == cartSanPhamDTO.maSanPham.ToLower());

            if (checkSpCoTrongGiohang != null)
            {
                checkSpCoTrongGiohang.SoLuongSp += 1;
                context.CartSanPhams.Update(checkSpCoTrongGiohang);
            }
            else
            {
                context.CartSanPhams.Add(new CartSanPham
                {
                    MaCart = cartSanPhamDTO.cartId,
                    GiaTien = cartSanPhamDTO.giaTien,
                    MaSanPham = cartSanPhamDTO.maSanPham,
                    SoLuongSp = cartSanPhamDTO.soLuongSp,
                });
            }

            await context.SaveChangesAsync();

            var cartToReturn = await context.Carts.Where(c => c.MaCart == cartSanPhamDTO.cartId)
                .Include(c => c.CartSanPhams)
                .ThenInclude(c => c.MaSanPhamNavigation)
                .FirstOrDefaultAsync();
            return cartToReturn;
        }




        //Comment
        public async Task<string> CreateMaCommentAsync()
        {
            List<string> comments = await context.Comments.Select(c => c.MaComment).ToListAsync();
            string lastID = "CM" + base.funcGetLastIndex(comments, 2);
            return lastID;
        }

        public async Task<CommentDTO> AddCommentAsync(CommentDTO comment, string productId, string personId)
        {

            var ngayBinhLuan = DateTime.Now;
            Comment newComment = new Comment
            {
                MaComment = await CreateMaCommentAsync(),
                NoiDungComment = comment.NoiDungComment,
                Star = comment.Star,
                NgayComment = ngayBinhLuan,
                PersonId = personId,
                MaSanPham = productId
            };

            context.Comments.Add(newComment);
            await context.SaveChangesAsync();
            comment.NgayComment = ngayBinhLuan;
            return comment;
        }




        //DatHang
        public string CreateMaDatHang()
        {
            List<string> madathangs = context.DatHangs.Select(dh => dh.MaDatHang).ToList();
            string lastID = "MaDatHang" + base.funcGetLastIndex(madathangs, 9);
            return lastID;
        }

        public async Task<DatHangDTO> AddDatHangAsync(string personId)
        {

            //từ personId lấy cart
            Cart cart = await context.Carts
                .FirstOrDefaultAsync(c => c.PersonId.ToLower() == personId.ToLower());

            if (cart == null)
            {
                return null;
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    //tạo mã đặt hàng
                    string maDatHang = CreateMaDatHang();


                    // từ cart lấy các sản phẩm
                    List<CartSanPham> cartProducts = await context.CartSanPhams
                        .Where(csp => csp.MaCart == cart.MaCart)
                        .Include(csp => csp.MaSanPhamNavigation).ToListAsync();

                    if (cartProducts.Count <= 0)
                    {
                        return null;
                    }

                    //lấy ra các sản phẩm rồi trừ số lượng sản phẩm hiện có
                    var products = context.SanPhams;
                    List<SanPham> productsToUpdate = new List<SanPham>();
                    foreach (var product in products)
                    {
                        foreach(var cartProduct in cartProducts)
                        {
                            if(product.MaSanPham == cartProduct.MaSanPham)
                            {
                                product.SoLuong = product.SoLuong - (cartProduct.SoLuongSp ?? 0);
                                if(product.SoLuong < 0)
                                {
                                    return null;
                                }
                                productsToUpdate.Add(product);
                                break;
                            }
                        }
                    }

                    context.SanPhams.UpdateRange(productsToUpdate);

                    var cartProductsToDatHangSanPham = cartProducts.Select(csp => new DatHangSanPham
                    {
                        MaDatHang = maDatHang,
                        MaSanPham = csp.MaSanPham,
                        SoLuong = csp.SoLuongSp,
                        GiaTien = csp.MaSanPhamNavigation.GiaSanPham,
                        TongTien = csp.SoLuongSp * csp.MaSanPhamNavigation.GiaSanPham
                    }).ToList();

                    // tạo đơn đặt hàng
                    DatHang newDatHang = new DatHang
                    {
                        MaDatHang = maDatHang,
                        NgayDatHang = DateTime.Now,
                        PersonId = personId,
                        DatHangSanPhams = cartProductsToDatHangSanPham
                    };
                    context.DatHangs.Add(newDatHang);

                    //sao khi đặt hàng xong thì xóa các sản phẩm có trong giỏ hàng
                    context.CartSanPhams.RemoveRange(cartProducts);

                    await context.SaveChangesAsync();

                    transaction.Commit();
                    return this.mapper.Map<DatHangDTO>(newDatHang);


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }


            }




        }


        public async Task<IEnumerable<DatHangDTO>> GetDatHangByPersonIdsAsync(string personId)
        {

            var dathangsDTO = await context.DatHangs.Where(dh => dh.PersonId == personId)
                .ProjectTo<DatHangDTO>(this.mapper.ConfigurationProvider).ToListAsync();

            if (dathangsDTO.Count <= 0)
            {
                return null;
            }

            return dathangsDTO;

        }

        public async Task<IEnumerable<DatHangDTO>> GetDatHangsAsync()
        {
            var dathangsDTO = await context.DatHangs.ProjectTo<DatHangDTO>(this.mapper.ConfigurationProvider).ToListAsync();

            if (dathangsDTO.Count <= 0)
            {
                return null;
            }

            return dathangsDTO;
        }


        //DatHangSanPham


        //HoaDon


        //KhachHang
        public string CreateMaKhachHang()
        {
            List<string> makhachhangs = context.KhachHangs.Select(kh => kh.MaKhachHang).ToList();
            string lastID = "KH" + base.funcGetLastIndex(makhachhangs, 2);
            return lastID;
        }

        public bool AddKhachHang(string makhachhang)
        {
            if (context.KhachHangs.Where(kh => kh.MaKhachHang == makhachhang).Any())
            {
                return false;
            }

            List<string> makhachhangs = new List<string>();
            string lastID = "KH" + base.funcGetLastIndex(makhachhangs, 2);
            context.KhachHangs.Add(new KhachHang
            {
                MaKhachHang = makhachhang,
            });
            context.SaveChanges();
            return true;
        }
        public async Task<IEnumerable<KhachHangDTO>> GetKhachHangsAsync()
        {
            var khachhangs = await context.KhachHangs.ProjectTo<KhachHangDTO>(this.mapper.ConfigurationProvider).ToListAsync();
            return khachhangs;
        }



        //LoaiTaiKhoan


        //MauSacSanPham


        //NhanVien
        public string CreateMaNhanVien()
        {
            List<string> manhanviens = context.NhanViens.Select(nv => nv.MaNhanVien).ToList();
            string lastID = "NV" + base.funcGetLastIndex(manhanviens, 2);
            return lastID;
        }

        

        public async Task<IEnumerable<NhanVienDTO>> GetNhanVienAsync()
        {
            var nhanviens = await context.NhanViens.ProjectTo<NhanVienDTO>(this.mapper.ConfigurationProvider).ToListAsync();

            if (nhanviens.Count() <= 0) return null;

            return nhanviens;

        }
        public async Task<CreateNhanVienDTO> AddNhanVienAsync(CreateNhanVienDTO thongTinNewNhanVien)
        {
            string manhanvien = CreateMaNhanVien();


            NhanVien newNhanVien = new NhanVien
            {
                MaNhanVien = manhanvien,
                NgayDuocTuyen = DateTime.Now,
                MaVaiTro = thongTinNewNhanVien.maVaiTro,
            };

            TaiKhoan newTaiKhoan = new TaiKhoan
            {
                MaTaiKhoan = CreateMaTaiKhoan(),
                Username = thongTinNewNhanVien.username,
                Password = thongTinNewNhanVien.password,
                MaLoaiTaiKhoan = "ltknhanvien",
                PersonId = manhanvien,
                Person = new Person
                {
                    PersonId = manhanvien,
                    HoTen = thongTinNewNhanVien.hoTen,
                    Tuoi = thongTinNewNhanVien.tuoi,
                    GioiTinh = thongTinNewNhanVien.gioiTinh,
                    Sdt = thongTinNewNhanVien.sdt,
                    DiaChi = thongTinNewNhanVien.diaChi,
                    Email = thongTinNewNhanVien.email
                }
            };

            context.NhanViens.Add(newNhanVien);
            context.TaiKhoans.Add(newTaiKhoan);
            await context.SaveChangesAsync();


            return thongTinNewNhanVien;
        }


        public async Task<CreateNhanVienDTO> UpdateNhanVienAsync(CreateNhanVienDTO updateNhanVien,string maNhanVien)
        {
            NhanVien nhanVien = await context.NhanViens.FirstOrDefaultAsync(nv => nv.MaNhanVien.ToLower() == maNhanVien.ToLower());

            if(nhanVien == null)
            {
                return null;
            }

            nhanVien.MaVaiTro = updateNhanVien.maVaiTro;
            Person thongTinNhanVien = await context.People.FirstOrDefaultAsync(p => p.PersonId.ToLower() == maNhanVien.ToLower());
            thongTinNhanVien.HoTen = updateNhanVien.hoTen;
            thongTinNhanVien.Tuoi = updateNhanVien.tuoi;
            thongTinNhanVien.GioiTinh = updateNhanVien.gioiTinh;
            thongTinNhanVien.Sdt = updateNhanVien.sdt;
            thongTinNhanVien.DiaChi = updateNhanVien.diaChi;
            thongTinNhanVien.Email = updateNhanVien.email;

            TaiKhoan taiKhoan = await context.TaiKhoans.FirstOrDefaultAsync(tk => tk.PersonId.ToLower() == maNhanVien.ToLower());
            taiKhoan.Username = updateNhanVien.username;
            taiKhoan.Password = updateNhanVien.password;

            if(updateNhanVien.maVaiTro == "quanly")
            {
                taiKhoan.MaLoaiTaiKhoan = "ltkadmin";
            }

            else if (updateNhanVien.maVaiTro == "nhanvien")
            {
                taiKhoan.MaLoaiTaiKhoan = "ltknhanvien";
            }



            context.Update(nhanVien);
            context.Update(thongTinNhanVien);
            context.Update(taiKhoan);
            await context.SaveChangesAsync();
            return updateNhanVien;
        }





        //Person

        public IEnumerable<Person> GetUsers => context.People;

        public async Task<PersonDTO> getUserByIdAsync(string id)
        {
            var s = await context.People.Where(p =>p.PersonId == id).ProjectTo<PersonDTO>(this.mapper.ConfigurationProvider).FirstOrDefaultAsync() ;
            return s;
        }
        public async Task<Person> UpdatePersonAsync(PersonDTO personDTO, string id)
        {
            var personNeedTobeUpdated = await context.People.FirstOrDefaultAsync(p => p.PersonId == id);
            if (personNeedTobeUpdated == null)
            {
                return null;
            }

            personNeedTobeUpdated.HoTen = personDTO.hoten;
            personNeedTobeUpdated.Tuoi = personDTO.tuoi;
            personNeedTobeUpdated.GioiTinh = personDTO.gioitinh;
            personNeedTobeUpdated.Sdt = personDTO.sdt;
            personNeedTobeUpdated.DiaChi = personDTO.diachi;
            personNeedTobeUpdated.Email = personDTO.email;

            context.People.Update(personNeedTobeUpdated);
            context.SaveChanges();
            return personNeedTobeUpdated;

        }




        //TaiKhoan
        public string CreateMaTaiKhoan()
        {
            List<string> mataikhoan = context.TaiKhoans.Select(tk => tk.MaTaiKhoan).ToList();
            string lastID = "TK" + base.funcGetLastIndex(mataikhoan, 2);
            return lastID;
        }

        public bool CreateAccount(TaiKhoan newTaiKhoan)
        {
            //kiểm tra user name có tồn tại không
            if (context.TaiKhoans.Where(tk => newTaiKhoan.Username.ToLower() == tk.Username.ToLower()).Any())
            {
                return false;
            }

            context.TaiKhoans.Add(newTaiKhoan);
            context.SaveChanges();
            return true;

        }

        public bool CheckTaiKhoanExist(LoginDTO login)
        {
            //đầu tiên kiểm tra tài khoản có tồn tại không
            var user = context.TaiKhoans.FirstOrDefault(tk => tk.Username == login.username);
            if (user == null)
            {
                return false;
            }
            return true;

        }

        public TaiKhoan CheckTaiKhoanVaMatKhauExist(LoginDTO login)
        {
            TaiKhoan taikhoan = context.TaiKhoans.Where(tk => tk.Username == login.username
            && tk.Password == login.password).Include(tk => tk.Person).FirstOrDefault();

            if (taikhoan == null)
            {
                return null;
            }
            return taikhoan;

        }

        public async Task<IEnumerable<AccountDTO>> GetAccountsAync()
        {
            var accounts = await context.TaiKhoans
                .Include(tk => tk.MaLoaiTaiKhoanNavigation)
                .Include(tk => tk.Person).ToListAsync();


            var accountDTOs = accounts.Select(tk => new AccountDTO
            {
                username = tk.Username,
                password = tk.Password,
                hoten = tk.Person.HoTen,
                tuoi = tk.Person.Tuoi,
                gioitinh = tk.Person.GioiTinh,
                sdt = tk.Person.Sdt,
                diachi = tk.Person.DiaChi,
                email = tk.Person.Email,
                loaitaikhoan = tk.MaLoaiTaiKhoanNavigation.TenLoaiTaiKhoan
            });

            return accountDTOs;

        }


        public async Task<AccountDTO> GetAccountByUserNameAync(string username)
        {
            var account = await context.TaiKhoans
               .Where(tk => tk.Username == username)
               .Include(tk => tk.MaLoaiTaiKhoanNavigation)
               .Include(tk => tk.Person).FirstOrDefaultAsync();


            var accountDTOs = new AccountDTO
            {
                username = account.Username,
                password = account.Password,
                hoten = account.Person.HoTen,
                tuoi = account.Person.Tuoi,
                gioitinh = account.Person.GioiTinh,
                sdt = account.Person.Sdt,
                diachi = account.Person.DiaChi,
                email = account.Person.Email,
                loaitaikhoan = account.MaLoaiTaiKhoanNavigation.TenLoaiTaiKhoan
            };

            return accountDTOs;
        }



        //ThacMacKhieuNai
        public string CreateMaKhieuNai()
        {
            List<string> makhieunai = context.ThacMacKhieuNais.Select(kn => kn.MaKhieuNai).ToList();
            string lastID = "TMKN" + base.funcGetLastIndex(makhieunai, 4);
            return lastID;
        }

        public async Task<IEnumerable<ThacMacKhieuNai>> GetKhieuNaiAsync()
        {
            return await context.ThacMacKhieuNais.ToListAsync();
        }

        public async Task<bool> PostKhieuNaiAsync(ThacMacKhieuNai thongtin)
        {
            await context.ThacMacKhieuNais.AddAsync(thongtin);
            return await context.SaveChangesAsync() >= 1 ? true : false;
        }

        public async Task<bool> DeleteThacMacKhieuNaiAsync(string id)
        {
            ThacMacKhieuNai thacmackieunai = await context.ThacMacKhieuNais.FindAsync(id);
            if (thacmackieunai == null)
            {
                return false;
            }

            context.ThacMacKhieuNais.Remove(thacmackieunai);
            return await context.SaveChangesAsync() > 0 ? true : false;
        }



        //TinhTrangSanPham
        public async Task<IEnumerable<TinhTrangSanPhamDTO>> GetTinhTrangSanPhamAsync()
        {
            return context.TinhTrangSanPhams.ProjectTo<TinhTrangSanPhamDTO>(this.mapper.ConfigurationProvider);
        }


        //VaiTroNhanVien
        public async Task<IEnumerable<VaiTroNhanVienDTO>> GetVaiTrosAsync()
        {
            return await context.VaiTroNhanViens.ProjectTo<VaiTroNhanVienDTO>(this.mapper.ConfigurationProvider).ToListAsync();
        }


        //Voucher


    }
}
