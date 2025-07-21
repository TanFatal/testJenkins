using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace back_end.Models
{
    public partial class EcommerceContext : DbContext
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartSanPham> CartSanPhams { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<DatHang> DatHangs { get; set; }
        public virtual DbSet<DatHangSanPham> DatHangSanPhams { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }
        public virtual DbSet<MauSacSanPham> MauSacSanPhams { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThacMacKhieuNai> ThacMacKhieuNais { get; set; }
        public virtual DbSet<TinhTrangSanPham> TinhTrangSanPhams { get; set; }
        public virtual DbSet<VaiTroNhanVien> VaiTroNhanViens { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Ecommerce;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.MaBrand)
                    .HasName("PK__Brand__2F06A75435B917E1");

                entity.ToTable("Brand");

                entity.Property(e => e.MaBrand).HasMaxLength(255);

                entity.Property(e => e.TenBrand).HasMaxLength(255);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.MaCart)
                    .HasName("PK__Cart__20E715D55FC0ECFA");

                entity.ToTable("Cart");

                entity.Property(e => e.MaCart).HasMaxLength(255);

                entity.Property(e => e.PersonId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCart142245");
            });

            modelBuilder.Entity<CartSanPham>(entity =>
            {
                entity.HasKey(e => new { e.MaCart, e.MaSanPham })
                    .HasName("PK__Cart_San__EF4B6197AB5222C9");

                entity.ToTable("Cart_SanPham");

                entity.Property(e => e.MaCart).HasMaxLength(255);

                entity.Property(e => e.MaSanPham).HasMaxLength(255);

                entity.Property(e => e.GiaTien).HasColumnType("numeric(19, 3)");

                entity.Property(e => e.SoLuongSp).HasColumnName("SoLuongSP");

                entity.HasOne(d => d.MaCartNavigation)
                    .WithMany(p => p.CartSanPhams)
                    .HasForeignKey(d => d.MaCart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCart_SanPh922696");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.CartSanPhams)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCart_SanPh844321");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.MaComment)
                    .HasName("PK__Comment__36A7276A3C1D7DAB");

                entity.ToTable("Comment");

                entity.Property(e => e.MaComment).HasMaxLength(255);

                entity.Property(e => e.MaSanPham)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NgayComment).HasColumnType("datetime");

                entity.Property(e => e.NoiDungComment).HasMaxLength(255);

                entity.Property(e => e.PersonId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("PersonID");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKComment786194");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKComment819342");
            });

            modelBuilder.Entity<DatHang>(entity =>
            {
                entity.HasKey(e => e.MaDatHang)
                    .HasName("PK__DatHang__1E77C2F0F8DB87C1");

                entity.ToTable("DatHang");

                entity.Property(e => e.MaDatHang).HasMaxLength(255);

                entity.Property(e => e.NgayDatHang).HasColumnType("datetime");

                entity.Property(e => e.PersonId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.DatHangs)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDatHang97666");
            });

            modelBuilder.Entity<DatHangSanPham>(entity =>
            {
                entity.HasKey(e => new { e.MaDatHang, e.MaSanPham })
                    .HasName("PK__DatHang___D1DBB6B28DDE0F4F");

                entity.ToTable("DatHang_SanPham");

                entity.Property(e => e.MaDatHang).HasMaxLength(255);

                entity.Property(e => e.MaSanPham).HasMaxLength(255);

                entity.Property(e => e.GiaTien).HasColumnType("numeric(19, 3)");

                entity.Property(e => e.TongTien).HasColumnType("numeric(19, 3)");

                entity.HasOne(d => d.MaDatHangNavigation)
                    .WithMany(p => p.DatHangSanPhams)
                    .HasForeignKey(d => d.MaDatHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDatHang_Sa64145");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.DatHangSanPhams)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDatHang_Sa135989");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK__HoaDon__835ED13B5652DE52");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHoaDon).HasMaxLength(255);

                entity.Property(e => e.MaDatHang)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NgayIn).HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnType("numeric(19, 3)");

                entity.HasOne(d => d.MaDatHangNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaDatHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHoaDon141997");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang)
                    .HasName("PK__KhachHan__88D2F0E51B44EF16");

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKhachHang).HasMaxLength(255);

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithOne(p => p.KhachHang)
                    .HasForeignKey<KhachHang>(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKKhachHang15206");
            });

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.MaLoaiSanPham)
                    .HasName("PK__LoaiSanP__ECCF699FE2539396");

                entity.ToTable("LoaiSanPham");

                entity.Property(e => e.MaLoaiSanPham).HasMaxLength(255);

                entity.Property(e => e.TenLoaiSanPham).HasMaxLength(255);

                entity.HasMany(d => d.MaBrands)
                    .WithMany(p => p.MaLoaiSanPhams)
                    .UsingEntity<Dictionary<string, object>>(
                        "LoaiSanPhamBrand",
                        l => l.HasOne<Brand>().WithMany().HasForeignKey("MaBrand").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKLoaiSanPha584096"),
                        r => r.HasOne<LoaiSanPham>().WithMany().HasForeignKey("MaLoaiSanPham").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKLoaiSanPha320643"),
                        j =>
                        {
                            j.HasKey("MaLoaiSanPham", "MaBrand").HasName("PK__LoaiSanP__BE3F03EADF0CD2D8");

                            j.ToTable("LoaiSanPham_Brand");

                            j.IndexerProperty<string>("MaLoaiSanPham").HasMaxLength(255);

                            j.IndexerProperty<string>("MaBrand").HasMaxLength(255);
                        });
            });

            modelBuilder.Entity<LoaiTaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaLoaiTaiKhoan)
                    .HasName("PK__LoaiTaiK__5F6E141C98096B06");

                entity.ToTable("LoaiTaiKhoan");

                entity.Property(e => e.MaLoaiTaiKhoan).HasMaxLength(255);

                entity.Property(e => e.TenLoaiTaiKhoan).HasMaxLength(255);
            });

            modelBuilder.Entity<MauSacSanPham>(entity =>
            {
                entity.HasKey(e => e.MaMauSac)
                    .HasName("PK__MauSacSa__B9A9116263E4B334");

                entity.ToTable("MauSacSanPham");

                entity.Property(e => e.MaMauSac).HasMaxLength(255);

                entity.Property(e => e.TenMauSac).HasMaxLength(255);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NhanVien__77B2CA47921843C5");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNhanVien).HasMaxLength(255);

                entity.Property(e => e.MaVaiTro)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NgayDuocTuyen).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithOne(p => p.NhanVien)
                    .HasForeignKey<NhanVien>(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNhanVien864260");

                entity.HasOne(d => d.MaVaiTroNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaVaiTro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKNhanVien670324");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(255)
                    .HasColumnName("PersonID");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(255)
                    .HasColumnName("CCCD");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.HoTen).HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham)
                    .HasName("PK__SanPham__FAC7442D78A26469");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSanPham).HasMaxLength(255);

                entity.Property(e => e.GiaSanPham).HasColumnType("numeric(19, 3)");

                entity.Property(e => e.HinhAnhSanPham).HasMaxLength(255);

                entity.Property(e => e.MaBrand)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.MaLoaiSanPham)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.MaTinhTrang)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.MoTaSanPham).HasMaxLength(255);

                entity.Property(e => e.TenSanPham).HasMaxLength(255);

                entity.HasOne(d => d.MaBrandNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSanPham467323");

                entity.HasOne(d => d.MaLoaiSanPhamNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaLoaiSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSanPham437416");

                entity.HasOne(d => d.MaTinhTrangNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaTinhTrang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSanPham397196");

                entity.HasMany(d => d.MaMauSacs)
                    .WithMany(p => p.MaSanPhams)
                    .UsingEntity<Dictionary<string, object>>(
                        "SanPhamMauSacSanPham",
                        l => l.HasOne<MauSacSanPham>().WithMany().HasForeignKey("MaMauSac").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKSanPham_Ma120529"),
                        r => r.HasOne<SanPham>().WithMany().HasForeignKey("MaSanPham").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKSanPham_Ma48895"),
                        j =>
                        {
                            j.HasKey("MaSanPham", "MaMauSac").HasName("PK__SanPham___C15DD53B3502945A");

                            j.ToTable("SanPham_MauSacSanPham");

                            j.IndexerProperty<string>("MaSanPham").HasMaxLength(255);

                            j.IndexerProperty<string>("MaMauSac").HasMaxLength(255);
                        });
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaTaiKhoan)
                    .HasName("PK__TaiKhoan__AD7C652980FCBE10");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.MaTaiKhoan).HasMaxLength(255);

                entity.Property(e => e.MaLoaiTaiKhoan)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PersonId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("PersonID");

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.HasOne(d => d.MaLoaiTaiKhoanNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.MaLoaiTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTaiKhoan852133");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTaiKhoan978872");
            });

            modelBuilder.Entity<ThacMacKhieuNai>(entity =>
            {
                entity.HasKey(e => e.MaKhieuNai)
                    .HasName("PK__ThacMacK__1D72BE52211E3ADA");

                entity.ToTable("ThacMacKhieuNai");

                entity.Property(e => e.MaKhieuNai).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.HoTen).HasMaxLength(255);

                entity.Property(e => e.NgayKieuNai).HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasMaxLength(255);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(255)
                    .HasColumnName("SDT");

                entity.Property(e => e.TieuDe).HasMaxLength(255);
            });

            modelBuilder.Entity<TinhTrangSanPham>(entity =>
            {
                entity.HasKey(e => e.MaTinhTrang)
                    .HasName("PK__TinhTran__89F8F669170488E7");

                entity.ToTable("TinhTrangSanPham");

                entity.Property(e => e.MaTinhTrang).HasMaxLength(255);

                entity.Property(e => e.TenTinhTrang).HasMaxLength(255);
            });

            modelBuilder.Entity<VaiTroNhanVien>(entity =>
            {
                entity.HasKey(e => e.MaVaiTro)
                    .HasName("PK__VaiTroNh__C24C41CFBDAD81FA");

                entity.ToTable("VaiTroNhanVien");

                entity.Property(e => e.MaVaiTro).HasMaxLength(255);

                entity.Property(e => e.TenVaiTro).HasMaxLength(255);
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.VoucherId)
                    .HasMaxLength(255)
                    .HasColumnName("VoucherID");

                entity.Property(e => e.MaVoucher).HasMaxLength(255);

                entity.Property(e => e.NgayHetHang).HasColumnType("datetime");

                entity.Property(e => e.NgayPhatHanh).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
