using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    MaBrand = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenBrand = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Brand__2F06A754F233D03D", x => x.MaBrand);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    MaLoaiSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenLoaiSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoaiSanP__ECCF699F592C9358", x => x.MaLoaiSanPham);
                });

            migrationBuilder.CreateTable(
                name: "LoaiTaiKhoan",
                columns: table => new
                {
                    MaLoaiTaiKhoan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenLoaiTaiKhoan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoaiTaiK__5F6E141C5EAD620F", x => x.MaLoaiTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "MauSacSanPham",
                columns: table => new
                {
                    MaMauSac = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenMauSac = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MauSacSa__B9A91162925E99C3", x => x.MaMauSac);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "ThacMacKhieuNai",
                columns: table => new
                {
                    MaKhieuNai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TieuDe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayKieuNai = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ThacMacK__1D72BE527AA1A8DE", x => x.MaKhieuNai);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangSanPham",
                columns: table => new
                {
                    MaTinhTrang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenTinhTrang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TinhTran__89F8F669096159AA", x => x.MaTinhTrang);
                });

            migrationBuilder.CreateTable(
                name: "VaiTroNhanVien",
                columns: table => new
                {
                    MaVaiTro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenVaiTro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VaiTroNh__C24C41CF2731FBBB", x => x.MaVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    VoucherID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaVoucher = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayPhatHanh = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayHetHang = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.VoucherID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPham_Brand",
                columns: table => new
                {
                    MaLoaiSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaBrand = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoaiSanP__BE3F03EA5C2E17F5", x => new { x.MaLoaiSanPham, x.MaBrand });
                    table.ForeignKey(
                        name: "FKLoaiSanPha320643",
                        column: x => x.MaLoaiSanPham,
                        principalTable: "LoaiSanPham",
                        principalColumn: "MaLoaiSanPham");
                    table.ForeignKey(
                        name: "FKLoaiSanPha584096",
                        column: x => x.MaBrand,
                        principalTable: "Brand",
                        principalColumn: "MaBrand");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    MaCart = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PersonID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__20E715D51900B431", x => x.MaCart);
                    table.ForeignKey(
                        name: "FKCart142245",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "DatHang",
                columns: table => new
                {
                    MaDatHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayDatHang = table.Column<DateTime>(type: "datetime", nullable: true),
                    PersonID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DatHang__1E77C2F0800A7D62", x => x.MaDatHang);
                    table.ForeignKey(
                        name: "FKDatHang97666",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKhachHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KhachHan__88D2F0E5E71F3913", x => x.MaKhachHang);
                    table.ForeignKey(
                        name: "FKKhachHang15206",
                        column: x => x.MaKhachHang,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PersonID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaLoaiTaiKhoan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaiKhoan__AD7C6529DBA89C4B", x => x.MaTaiKhoan);
                    table.ForeignKey(
                        name: "FKTaiKhoan852133",
                        column: x => x.MaLoaiTaiKhoan,
                        principalTable: "LoaiTaiKhoan",
                        principalColumn: "MaLoaiTaiKhoan");
                    table.ForeignKey(
                        name: "FKTaiKhoan978872",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GiaSanPham = table.Column<decimal>(type: "numeric(19,3)", nullable: true),
                    MoTaSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    HinhAnhSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaTinhTrang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaBrand = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaLoaiSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SanPham__FAC7442DE5565939", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "FKSanPham397196",
                        column: x => x.MaTinhTrang,
                        principalTable: "TinhTrangSanPham",
                        principalColumn: "MaTinhTrang");
                    table.ForeignKey(
                        name: "FKSanPham437416",
                        column: x => x.MaLoaiSanPham,
                        principalTable: "LoaiSanPham",
                        principalColumn: "MaLoaiSanPham");
                    table.ForeignKey(
                        name: "FKSanPham467323",
                        column: x => x.MaBrand,
                        principalTable: "Brand",
                        principalColumn: "MaBrand");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayDuocTuyen = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaVaiTro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__77B2CA47F146AF7D", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FKNhanVien670324",
                        column: x => x.MaVaiTro,
                        principalTable: "VaiTroNhanVien",
                        principalColumn: "MaVaiTro");
                    table.ForeignKey(
                        name: "FKNhanVien864260",
                        column: x => x.MaNhanVien,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    TongTien = table.Column<decimal>(type: "numeric(19,3)", nullable: true),
                    MaDatHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HoaDon__835ED13BBD83EF84", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FKHoaDon141997",
                        column: x => x.MaDatHang,
                        principalTable: "DatHang",
                        principalColumn: "MaDatHang");
                });

            migrationBuilder.CreateTable(
                name: "Cart_SanPham",
                columns: table => new
                {
                    MaCart = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart_San__EF4B619769C137C3", x => new { x.MaCart, x.MaSanPham });
                    table.ForeignKey(
                        name: "FKCart_SanPh844321",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham");
                    table.ForeignKey(
                        name: "FKCart_SanPh922696",
                        column: x => x.MaCart,
                        principalTable: "Cart",
                        principalColumn: "MaCart");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    MaComment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NoiDungComment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Star = table.Column<int>(type: "int", nullable: false),
                    NgayComment = table.Column<DateTime>(type: "datetime", nullable: true),
                    PersonID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comment__36A7276A2F0AF3C3", x => x.MaComment);
                    table.ForeignKey(
                        name: "FKComment786194",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham");
                    table.ForeignKey(
                        name: "FKComment819342",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "DatHang_SanPham",
                columns: table => new
                {
                    MaDatHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    GiaTien = table.Column<decimal>(type: "numeric(19,3)", nullable: true),
                    TongTien = table.Column<decimal>(type: "numeric(19,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DatHang___D1DBB6B2AE2207C5", x => new { x.MaDatHang, x.MaSanPham });
                    table.ForeignKey(
                        name: "FKDatHang_Sa135989",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham");
                    table.ForeignKey(
                        name: "FKDatHang_Sa64145",
                        column: x => x.MaDatHang,
                        principalTable: "DatHang",
                        principalColumn: "MaDatHang");
                });

            migrationBuilder.CreateTable(
                name: "SanPham_MauSacSanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaMauSac = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SanPham___C15DD53BA3AB5F7F", x => new { x.MaSanPham, x.MaMauSac });
                    table.ForeignKey(
                        name: "FKSanPham_Ma120529",
                        column: x => x.MaMauSac,
                        principalTable: "MauSacSanPham",
                        principalColumn: "MaMauSac");
                    table.ForeignKey(
                        name: "FKSanPham_Ma48895",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PersonID",
                table: "Cart",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_SanPham_MaSanPham",
                table: "Cart_SanPham",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MaSanPham",
                table: "Comment",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PersonID",
                table: "Comment",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_DatHang_PersonID",
                table: "DatHang",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_DatHang_SanPham_MaSanPham",
                table: "DatHang_SanPham",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaDatHang",
                table: "HoaDon",
                column: "MaDatHang");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPham_Brand_MaBrand",
                table: "LoaiSanPham_Brand",
                column: "MaBrand");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaVaiTro",
                table: "NhanVien",
                column: "MaVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaBrand",
                table: "SanPham",
                column: "MaBrand");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaLoaiSanPham",
                table: "SanPham",
                column: "MaLoaiSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaTinhTrang",
                table: "SanPham",
                column: "MaTinhTrang");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MauSacSanPham_MaMauSac",
                table: "SanPham_MauSacSanPham",
                column: "MaMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_MaLoaiTaiKhoan",
                table: "TaiKhoan",
                column: "MaLoaiTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_PersonID",
                table: "TaiKhoan",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart_SanPham");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "DatHang_SanPham");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "LoaiSanPham_Brand");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "SanPham_MauSacSanPham");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "ThacMacKhieuNai");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "DatHang");

            migrationBuilder.DropTable(
                name: "VaiTroNhanVien");

            migrationBuilder.DropTable(
                name: "MauSacSanPham");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "LoaiTaiKhoan");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "TinhTrangSanPham");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
