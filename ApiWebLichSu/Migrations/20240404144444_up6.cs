using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class up6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.AddColumn<string>(
           name: "UsersID_USER",
           table: "Quest",
           nullable: true,
           maxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
