using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class up11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswerQuestid_Answer",       // Tên cột cũ
                table: "Question",   // Tên bảng chứa cột
                newName: "id_Answer"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
