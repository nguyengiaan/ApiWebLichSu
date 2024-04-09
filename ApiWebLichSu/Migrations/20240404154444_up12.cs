using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class up12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                            name: "AnswerQuestid_Answer",
                            table: "Question",
                            nullable: true,
                            maxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
