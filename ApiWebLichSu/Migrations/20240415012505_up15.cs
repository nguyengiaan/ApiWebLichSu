using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class up15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn
            (
                name: "DATESUBMIT",
                table:"History"
             );  
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
