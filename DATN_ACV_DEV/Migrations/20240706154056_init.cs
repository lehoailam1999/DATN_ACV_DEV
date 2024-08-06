using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATN_ACV_DEV.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_AdressDelivery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    provinceName = table.Column<string>(type: "nvarchar(max)", nullable: false, collation: "Latin1_General_CI_AS"),
                    proviceId = table.Column<int>(type: "int", nullable: false),
                    districtName = table.Column<string>(type: "nvarchar(max)", nullable: false, collation: "Latin1_General_CI_AS"),
                    districtId = table.Column<int>(type: "int", nullable: false),
                    wardName = table.Column<string>(type: "nvarchar(max)", nullable: false, collation: "Latin1_General_CI_AS"),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true),
                    accountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    receiverName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, collation: "Latin1_General_CI_AS"),
                    receiverPhone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, collation: "Latin1_General_CI_AS"),
                    wardCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Latin1_General_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AdressDelivery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Category",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, collation: "Latin1_General_CI_AS"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Latin1_General_CI_AS"),
                    Status = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Customers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Image",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false, collation: "Latin1_General_CI_AS"),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, collation: "Latin1_General_CI_AS"),
                    InAcitve = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Image", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Invoice",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, collation: "Latin1_General_CI_AS"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    InputDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Invoice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_PaymentMethod",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, collation: "Latin1_General_CI_AS"),
                    CardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Latin1_General_CI_AS"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Latin1_General_CI_AS"),
                    InActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PaymentMethod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Voucher",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, collation: "Latin1_General_CI_AS"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "Latin1_General_CI_AS"),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Latin1_General_CI_AS"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Latin1_General_CI_AS"),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Latin1_General_CI_AS"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Latin1_General_CI_AS"),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Voucher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, collation: "Latin1_General_CI_AS"),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Latin1_General_CI_AS"),
                    PriceNet = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, collation: "Latin1_General_CI_AS"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Products_tb_Category",
                        column: x => x.CategoryID,
                        principalTable: "tb_Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_Account",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDelete = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressDeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Account_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Account_tb_AdressDelivery",
                        column: x => x.AddressDeliveryId,
                        principalTable: "tb_AdressDelivery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_Account_tb_Customers",
                        column: x => x.CustomerID,
                        principalTable: "tb_Customers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_InvoiceDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "Latin1_General_CI_AS"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, collation: "Latin1_General_CI_AS"),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdInvoice = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_InvoiceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_InvoiceDetail_tb_Invoice",
                        column: x => x.IdInvoice,
                        principalTable: "tb_Invoice",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_InvoiceDetail_tb_Products",
                        column: x => x.ProductID,
                        principalTable: "tb_Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tbAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_tb_Account_tbAccountId",
                        column: x => x.tbAccountId,
                        principalTable: "tb_Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Order",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivered = table.Column<int>(type: "int", nullable: true),
                    DeliveredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NameCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    VoucherID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AcountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Order_tb_Account",
                        column: x => x.AcountID,
                        principalTable: "tb_Account",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_Order_tb_PaymentMethod",
                        column: x => x.PaymentMethodID,
                        principalTable: "tb_PaymentMethod",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_Order_tb_Voucher",
                        column: x => x.VoucherID,
                        principalTable: "tb_Voucher",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_OderDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_OderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_OderDetail_tb_Order",
                        column: x => x.OrderID,
                        principalTable: "tb_Order",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_OderDetail_tb_Products",
                        column: x => x.ProductID,
                        principalTable: "tb_Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_ExchangeItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_ExchangeItems_tb_OderDetail",
                        column: x => x.OrderDetailId,
                        principalTable: "tb_OderDetail",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_ReturnItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnOder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_ReturnItem_tb_OderDetail",
                        column: x => x.OrderDetailId,
                        principalTable: "tb_OderDetail",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_tbAccountId",
                table: "RefreshTokens",
                column: "tbAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Account_AddressDeliveryId",
                table: "tb_Account",
                column: "AddressDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Account_CustomerID",
                table: "tb_Account",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Account_RoleId",
                table: "tb_Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ExchangeItems_OrderDetailId",
                table: "tb_ExchangeItems",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_InvoiceDetail_IdInvoice",
                table: "tb_InvoiceDetail",
                column: "IdInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_tb_InvoiceDetail_ProductID",
                table: "tb_InvoiceDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OderDetail_OrderID",
                table: "tb_OderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OderDetail_ProductID",
                table: "tb_OderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Order_AcountID",
                table: "tb_Order",
                column: "AcountID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Order_PaymentMethodID",
                table: "tb_Order",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Order_VoucherID",
                table: "tb_Order",
                column: "VoucherID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Products_CategoryID",
                table: "tb_Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ReturnItem_OrderDetailId",
                table: "tb_ReturnItem",
                column: "OrderDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "tb_ExchangeItems");

            migrationBuilder.DropTable(
                name: "tb_Image");

            migrationBuilder.DropTable(
                name: "tb_InvoiceDetail");

            migrationBuilder.DropTable(
                name: "tb_ReturnItem");

            migrationBuilder.DropTable(
                name: "tb_Invoice");

            migrationBuilder.DropTable(
                name: "tb_OderDetail");

            migrationBuilder.DropTable(
                name: "tb_Order");

            migrationBuilder.DropTable(
                name: "tb_Products");

            migrationBuilder.DropTable(
                name: "tb_Account");

            migrationBuilder.DropTable(
                name: "tb_PaymentMethod");

            migrationBuilder.DropTable(
                name: "tb_Voucher");

            migrationBuilder.DropTable(
                name: "tb_Category");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "tb_AdressDelivery");

            migrationBuilder.DropTable(
                name: "tb_Customers");
        }
    }
}
