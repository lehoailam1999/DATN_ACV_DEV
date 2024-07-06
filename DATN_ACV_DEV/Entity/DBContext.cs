using System;
using System.Collections.Generic;
using DATN_ACV_DEV.Entity;
using Microsoft.EntityFrameworkCore;

namespace DATN_ACV_DEV.Entity_ALB;

public partial class DBContext : DbContext, IAppDbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAccount> TbAccounts { get; set; }

    public virtual DbSet<TbAdressDelivery> TbAdressDeliveries { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbExchangeItem> TbExchangeItems { get; set; }

    public virtual DbSet<TbImage> TbImages { get; set; }

    public virtual DbSet<TbInvoice> TbInvoices { get; set; }

    public virtual DbSet<TbInvoiceDetail> TbInvoiceDetails { get; set; }

    public virtual DbSet<TbOderDetail> TbOderDetails { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbPaymentMethod> TbPaymentMethods { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbReturnItem> TbReturnItems { get; set; }

    public virtual DbSet<TbVoucher> TbVouchers { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public async Task<int> CommitChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public DbSet<TEntity> SetEntity<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-ME11437\\SQLEXPRESS;Initial Catalog=DATN_ALB;Integrated Security=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Account");

            entity.ToTable("tb_Account");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.IsDelete)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AddressDelivery).WithMany(p => p.TbAccounts)
                .HasForeignKey(d => d.AddressDeliveryId)
                .HasConstraintName("FK_tb_Account_tb_AdressDelivery");

            entity.HasOne(d => d.Customer).WithMany(p => p.TbAccounts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tb_Account_tb_Customers");
        });

        modelBuilder.Entity<TbAdressDelivery>(entity =>
        {
            entity.ToTable("tb_AdressDelivery");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.DistrictId).HasColumnName("districtId");
            entity.Property(e => e.DistrictName)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("districtName");
            entity.Property(e => e.IsDelete).HasColumnName("isDelete");
            entity.Property(e => e.ProviceId).HasColumnName("proviceId");
            entity.Property(e => e.ProvinceName)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("provinceName");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(255)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("receiverName");
            entity.Property(e => e.ReceiverPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("receiverPhone");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.WardCode)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("wardCode");
            entity.Property(e => e.WardName)
                .UseCollation("Latin1_General_CI_AS")
                .HasColumnName("wardName");
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.ToTable("tb_Category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.ToTable("tb_Customers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.YearOfBirth).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbExchangeItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ExchangeItems");

            entity.ToTable("tb_ExchangeItems");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.TbExchangeItems)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK_tb_ExchangeItems_tb_OderDetail");
        });

        modelBuilder.Entity<TbImage>(entity =>
        {
            entity.ToTable("tb_Image");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.InAcitve)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Type)
                .HasMaxLength(250)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Url).UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<TbInvoice>(entity =>
        {
            entity.ToTable("tb_Invoice");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(250)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InputDate).HasColumnType("datetime");
            entity.Property(e => e.IsDelete)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbInvoiceDetail>(entity =>
        {
            entity.ToTable("tb_InvoiceDetail");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");

            entity.HasOne(d => d.IdInvoiceNavigation).WithMany(p => p.TbInvoiceDetails)
                .HasForeignKey(d => d.IdInvoice)
                .HasConstraintName("FK_tb_InvoiceDetail_tb_Invoice");

            entity.HasOne(d => d.Product).WithMany(p => p.TbInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_InvoiceDetail_tb_Products");
        });

        modelBuilder.Entity<TbOderDetail>(entity =>
        {
            entity.ToTable("tb_OderDetail");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.TbOderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_OderDetail_tb_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.TbOderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_OderDetail_tb_Products");
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Order");

            entity.ToTable("tb_Order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AcountId).HasColumnName("AcountID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveredDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

            entity.HasOne(d => d.Acount).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.AcountId)
                .HasConstraintName("FK_tb_Order_tb_Account");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK_tb_Order_tb_PaymentMethod");

            entity.HasOne(d => d.Voucher).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_tb_Order_tb_Voucher");
        });

        modelBuilder.Entity<TbPaymentMethod>(entity =>
        {
            entity.ToTable("tb_PaymentMethod");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.InActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.ToTable("tb_Products");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.ImageId).HasColumnName("ImageID");
            entity.Property(e => e.IsDelete)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PriceNet).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.TbProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_Products_tb_Category");
        });

        modelBuilder.Entity<TbReturnItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ReturnOder");

            entity.ToTable("tb_ReturnItem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.TbReturnItems)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK_tb_ReturnItem_tb_OderDetail");
        });

       /* modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RefreshToken");

            entity.ToTable("tb_RefreshToken");

        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Role");

            entity.ToTable("tb_Role");

        });*/

        modelBuilder.Entity<TbVoucher>(entity =>
        {
            entity.ToTable("tb_Voucher");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Name).UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
