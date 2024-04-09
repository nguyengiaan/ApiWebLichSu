using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class up4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Users_USERSID_USER",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_USERSID_USER",
                table: "History");

            migrationBuilder.DropColumn(
                name: "USERSID_USER",
                table: "History");

            migrationBuilder.AlterColumn<string>(
                name: "USERNAME",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORD_USER",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME_USER",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_History_ID_USER",
                table: "History",
                column: "ID_USER");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Users_ID_USER",
                table: "History",
                column: "ID_USER",
                principalTable: "Users",
                principalColumn: "ID_USER",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
