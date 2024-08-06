using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATN_ACV_DEV.Migrations
{
    /// <inheritdoc />
    public partial class addconfirmEmail1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_tb_Account_tbAccountId",
                table: "ConfirmEmail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfirmEmail",
                table: "ConfirmEmail");

            migrationBuilder.RenameTable(
                name: "ConfirmEmail",
                newName: "ConfirmEmails");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmEmail_tbAccountId",
                table: "ConfirmEmails",
                newName: "IX_ConfirmEmails_tbAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfirmEmails",
                table: "ConfirmEmails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmails_tb_Account_tbAccountId",
                table: "ConfirmEmails",
                column: "tbAccountId",
                principalTable: "tb_Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmails_tb_Account_tbAccountId",
                table: "ConfirmEmails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfirmEmails",
                table: "ConfirmEmails");

            migrationBuilder.RenameTable(
                name: "ConfirmEmails",
                newName: "ConfirmEmail");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmEmails_tbAccountId",
                table: "ConfirmEmail",
                newName: "IX_ConfirmEmail_tbAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfirmEmail",
                table: "ConfirmEmail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_tb_Account_tbAccountId",
                table: "ConfirmEmail",
                column: "tbAccountId",
                principalTable: "tb_Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
