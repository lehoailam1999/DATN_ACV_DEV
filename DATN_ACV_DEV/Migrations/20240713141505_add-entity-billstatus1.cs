using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATN_ACV_DEV.Migrations
{
    /// <inheritdoc />
    public partial class addentitybillstatus1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Order_BillStatusId",
                table: "tb_Order",
                column: "BillStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Order_BillStatuses_BillStatusId",
                table: "tb_Order",
                column: "BillStatusId",
                principalTable: "BillStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Order_BillStatuses_BillStatusId",
                table: "tb_Order");

            migrationBuilder.DropTable(
                name: "BillStatuses");

            migrationBuilder.DropIndex(
                name: "IX_tb_Order_BillStatusId",
                table: "tb_Order");
        }
    }
}
