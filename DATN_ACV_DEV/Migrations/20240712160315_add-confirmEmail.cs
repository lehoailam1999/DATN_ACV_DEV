using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATN_ACV_DEV.Migrations
{
    /// <inheritdoc />
    public partial class addconfirmEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tbAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmEmail_tb_Account_tbAccountId",
                        column: x => x.tbAccountId,
                        principalTable: "tb_Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmEmail_tbAccountId",
                table: "ConfirmEmail",
                column: "tbAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmEmail");
        }
    }
}
