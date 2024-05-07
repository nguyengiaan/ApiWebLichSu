using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class up14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_History_ID_USER",
             table: "History");
            migrationBuilder.DropColumn(name:"ID_USER", "History");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
