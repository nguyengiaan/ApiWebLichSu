using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class up2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            try
            {
                migrationBuilder.DropIndex(
                    name: "IX_Quest_ID_USER",
                    table: "Quest"
                );
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log)
                Console.WriteLine($"Lỗi khi thực hiện Drop Index: {ex.Message}");
            }

            migrationBuilder.DropColumn(
                name: "ID_USER",
                table: "Quest"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        
        }
    }
}
