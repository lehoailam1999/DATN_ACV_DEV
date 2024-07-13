﻿// <auto-generated />
using System;
using DATN_ACV_DEV.Entity_ALB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DATN_ACV_DEV.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DATN_ACV_DEV.Entity.ConfirmEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodeActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiredTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<Guid>("tbAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("tbAccountId");

                    b.ToTable("ConfirmEmails");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiresTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("tbAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("tbAccountId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid?>("AddressDeliveryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IsDelete")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_Account");

                    b.HasIndex("AddressDeliveryId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RoleId");

                    b.ToTable("tb_Account", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbAdressDelivery", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountId");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int")
                        .HasColumnName("districtId");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("districtName")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("isDelete");

                    b.Property<int>("ProviceId")
                        .HasColumnType("int")
                        .HasColumnName("proviceId");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("provinceName")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<string>("ReceiverName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("receiverName")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<string>("ReceiverPhone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("receiverPhone")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<string>("WardCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("wardCode")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<string>("WardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("wardName")
                        .UseCollation("Latin1_General_CI_AS");

                    b.HasKey("Id");

                    b.ToTable("tb_AdressDelivery", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("tb_Category", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("Sex")
                        .HasColumnType("int");

                    b.Property<DateTime?>("YearOfBirth")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("tb_Customers", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbExchangeItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_ExchangeItems");

                    b.HasIndex("OrderDetailId");

                    b.ToTable("tb_ExchangeItems", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbImage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid?>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("InAcitve")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductID");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.HasKey("Id");

                    b.ToTable("tb_Image", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbInvoice", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("InputDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsDelete")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<Guid?>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("tb_Invoice", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbInvoiceDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdInvoice")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductID");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Unit")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.HasKey("Id");

                    b.HasIndex("IdInvoice");

                    b.HasIndex("ProductId");

                    b.ToTable("tb_InvoiceDetail", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbOderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderID");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("tb_OderDetail", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid?>("AcountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AcountID");

                    b.Property<Guid?>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("Delivered")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveredDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCustomer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PaymentMethodId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PaymentMethodID");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<Guid?>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("VoucherId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("VoucherID");

                    b.HasKey("Id")
                        .HasName("PK_Order");

                    b.HasIndex("AcountId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("VoucherId");

                    b.ToTable("tb_Order", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbPaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("CardNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<bool?>("InActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.HasKey("Id");

                    b.ToTable("tb_PaymentMethod", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ImageID");

                    b.Property<bool?>("IsDelete")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal?>("PriceNet")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("tb_Products", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbReturnItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_ReturnOder");

                    b.HasIndex("OrderDetailId");

                    b.ToTable("tb_ReturnItem", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbVoucher", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<string>("Unit")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .UseCollation("Latin1_General_CI_AS");

                    b.Property<Guid?>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("tb_Voucher", (string)null);
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity.ConfirmEmail", b =>
                {
                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbAccount", "tbAccount")
                        .WithMany("confirmEmail")
                        .HasForeignKey("tbAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tbAccount");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity.RefreshToken", b =>
                {
                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbAccount", "tbAccount")
                        .WithMany("refreshToken")
                        .HasForeignKey("tbAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tbAccount");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbAccount", b =>
                {
                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbAdressDelivery", "AddressDelivery")
                        .WithMany("TbAccounts")
                        .HasForeignKey("AddressDeliveryId")
                        .HasConstraintName("FK_tb_Account_tb_AdressDelivery");

                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbCustomer", "Customer")
                        .WithMany("TbAccounts")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_tb_Account_tb_Customers");

                    b.HasOne("DATN_ACV_DEV.Entity.Role", "role")
                        .WithMany("tbAccounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressDelivery");

                    b.Navigation("Customer");

                    b.Navigation("role");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbExchangeItem", b =>
                {
                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbOderDetail", "OrderDetail")
                        .WithMany("TbExchangeItems")
                        .HasForeignKey("OrderDetailId")
                        .HasConstraintName("FK_tb_ExchangeItems_tb_OderDetail");

                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbInvoiceDetail", b =>
                {
                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbInvoice", "IdInvoiceNavigation")
                        .WithMany("TbInvoiceDetails")
                        .HasForeignKey("IdInvoice")
                        .HasConstraintName("FK_tb_InvoiceDetail_tb_Invoice");

                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbProduct", "Product")
                        .WithMany("TbInvoiceDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_tb_InvoiceDetail_tb_Products");

                    b.Navigation("IdInvoiceNavigation");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbOderDetail", b =>
                {
                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbOrder", "Order")
                        .WithMany("TbOderDetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_tb_OderDetail_tb_Order");

                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbProduct", "Product")
                        .WithMany("TbOderDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_tb_OderDetail_tb_Products");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbOrder", b =>
                {
                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbAccount", "Acount")
                        .WithMany("TbOrders")
                        .HasForeignKey("AcountId")
                        .HasConstraintName("FK_tb_Order_tb_Account");

                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbPaymentMethod", "PaymentMethod")
                        .WithMany("TbOrders")
                        .HasForeignKey("PaymentMethodId")
                        .HasConstraintName("FK_tb_Order_tb_PaymentMethod");

                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbVoucher", "Voucher")
                        .WithMany("TbOrders")
                        .HasForeignKey("VoucherId")
                        .HasConstraintName("FK_tb_Order_tb_Voucher");

                    b.Navigation("Acount");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbProduct", b =>
                {
                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbCategory", "Category")
                        .WithMany("TbProducts")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_tb_Products_tb_Category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbReturnItem", b =>
                {
                    b.HasOne("DATN_ACV_DEV.Entity_ALB.TbOderDetail", "OrderDetail")
                        .WithMany("TbReturnItems")
                        .HasForeignKey("OrderDetailId")
                        .HasConstraintName("FK_tb_ReturnItem_tb_OderDetail");

                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity.Role", b =>
                {
                    b.Navigation("tbAccounts");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbAccount", b =>
                {
                    b.Navigation("TbOrders");

                    b.Navigation("confirmEmail");

                    b.Navigation("refreshToken");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbAdressDelivery", b =>
                {
                    b.Navigation("TbAccounts");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbCategory", b =>
                {
                    b.Navigation("TbProducts");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbCustomer", b =>
                {
                    b.Navigation("TbAccounts");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbInvoice", b =>
                {
                    b.Navigation("TbInvoiceDetails");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbOderDetail", b =>
                {
                    b.Navigation("TbExchangeItems");

                    b.Navigation("TbReturnItems");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbOrder", b =>
                {
                    b.Navigation("TbOderDetails");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbPaymentMethod", b =>
                {
                    b.Navigation("TbOrders");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbProduct", b =>
                {
                    b.Navigation("TbInvoiceDetails");

                    b.Navigation("TbOderDetails");
                });

            modelBuilder.Entity("DATN_ACV_DEV.Entity_ALB.TbVoucher", b =>
                {
                    b.Navigation("TbOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
