using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class alcoholContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@" Data Source=3078696.nat123.cc,33143;Initial Catalog=alcohol;Persist Security Info=True;User ID=sa;Password=sa1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.ProviderKey).HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserRoles_UserId");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PK_AspNetUserTokens");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => new { e.CustomerUserName, e.ProductNo })
                    .HasName("CartPK");

                entity.Property(e => e.CustomerUserName).HasColumnType("varchar(8)");

                entity.Property(e => e.ProductNo).HasColumnType("varchar(20)");

                entity.HasOne(d => d.CustomerUserNameNavigation)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.CustomerUserName)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("CartFK2");

                entity.HasOne(d => d.ProductNoNavigation)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductNo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("CartFK1");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerUserName)
                    .HasName("CustomerPK");

                entity.Property(e => e.CustomerUserName).HasColumnType("varchar(8)");

                entity.Property(e => e.CustomerId).ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerPassword)
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.CustomerSex).HasColumnType("varchar(2)");

                entity.Property(e => e.CustomerTel).HasColumnType("numeric");

                entity.Property(e => e.Email).HasColumnType("char(50)");

                entity.Property(e => e.Qq)
                    .HasColumnName("QQ")
                    .HasColumnType("char(11)");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Orders__4616479E27D74FAD");

                entity.Property(e => e.Amt).HasColumnName("amt");

                entity.Property(e => e.CustomerUserName).HasColumnType("varchar(8)");

                entity.Property(e => e.OrderAddress).HasColumnType("varchar(100)");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnType("char(10)");

                entity.Property(e => e.OrderState).HasColumnType("char(10)");

                entity.Property(e => e.Phone).HasColumnType("char(14)");

                entity.Property(e => e.ProductNo).HasColumnType("varchar(20)");

                entity.HasOne(d => d.CustomerUserNameNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerUserName)
                    .HasConstraintName("OrderFK1");

                entity.HasOne(d => d.PaymentNoNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentNo)
                    .HasConstraintName("OrderFK3");

                entity.HasOne(d => d.ProductNoNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductNo)
                    .HasConstraintName("OrderFK2");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Payment__4616479E4BFD7BFE");

                entity.Property(e => e.TransNo).HasColumnType("nchar(16)");

                entity.Property(e => e.TransTime).HasColumnType("datetime");

                entity.HasOne(d => d.ThePaymentTypeNavigation)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.ThePaymentType)
                    .HasConstraintName("PaymentFK1");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__PaymentT__4616479E6B978FB6");

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasMaxLength(80);

                entity.Property(e => e.MethodName).HasColumnType("nchar(50)");

                entity.Property(e => e.TypeName).HasColumnType("varchar(20)");

                entity.Property(e => e.Url).HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Pdetail>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__PDetail__4616479ED893013D");

                entity.ToTable("PDetail");

                entity.Property(e => e.Chucangtiaojian).HasColumnType("varchar(60)");

                entity.Property(e => e.Gongyi).HasColumnType("varchar(60)");

                entity.Property(e => e.Jinghanliang).HasColumnType("varchar(10)");

                entity.Property(e => e.Jiuchang).HasColumnType("varchar(40)");

                entity.Property(e => e.Jiujingdu).HasColumnType("varchar(10)");

                entity.Property(e => e.ProductNo).HasColumnType("varchar(20)");

                entity.Property(e => e.XiangXing).HasColumnType("varchar(20)");

                entity.Property(e => e.Xianggui).HasColumnType("varchar(10)");

                entity.Property(e => e.Yuanliao).HasColumnType("varchar(60)");

                entity.HasOne(d => d.ProductNoNavigation)
                    .WithMany(p => p.Pdetail)
                    .HasForeignKey(d => d.ProductNo)
                    .HasConstraintName("PDetailFK1");
            });

            modelBuilder.Entity<Ppics>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__PPics__4616479EC689B8F1");

                entity.ToTable("PPics");

                entity.Property(e => e.PicName).HasColumnType("varchar(20)");

                entity.Property(e => e.PicType).HasColumnType("varchar(1)");

                entity.Property(e => e.ProductNo).HasColumnType("varchar(20)");

                entity.HasOne(d => d.ProductNoNavigation)
                    .WithMany(p => p.Ppics)
                    .HasForeignKey(d => d.ProductNo)
                    .HasConstraintName("PPicsFK1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductNo)
                    .HasName("ProductPK");

                entity.Property(e => e.ProductNo).HasColumnType("varchar(20)");

                entity.Property(e => e.Price).HasColumnType("numeric");

                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<ProductClassification>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PCPK");

                entity.Property(e => e.Classification).HasColumnType("varchar(10)");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<ProductClassify>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__ProductC__4616479E5CCACFE9");

                entity.Property(e => e.ProductNo).HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.StaffLgId)
                    .HasName("StaffPK");

                entity.Property(e => e.StaffLgId).HasColumnType("varchar(10)");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.StaffAddr).HasColumnType("varchar(30)");

                entity.Property(e => e.StaffId).ValueGeneratedOnAdd();

                entity.Property(e => e.StaffName).HasColumnType("varchar(8)");

                entity.Property(e => e.StaffPassword)
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.StaffSex).HasColumnType("varchar(2)");

                entity.Property(e => e.Tel).HasColumnType("numeric");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.ProductNo)
                    .HasName("StockPK");

                entity.Property(e => e.ProductNo).HasColumnType("varchar(20)");

                entity.HasOne(d => d.ProductNoNavigation)
                    .WithOne(p => p.Stock)
                    .HasForeignKey<Stock>(d => d.ProductNo)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("StockFK1");
            });
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Pdetail> Pdetail { get; set; }
        public virtual DbSet<Ppics> Ppics { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductClassification> ProductClassification { get; set; }
        public virtual DbSet<ProductClassify> ProductClassify { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
    }
}