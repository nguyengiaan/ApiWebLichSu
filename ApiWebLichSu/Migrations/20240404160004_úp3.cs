using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class úp3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>
          (
               name: "Id",
               table: "QuestCollection",
               nullable: true,
               maxLength: 450
          );
            migrationBuilder.AddForeignKey(
            name: "FK_QuestCollection_Users_ID_USER",
            table: "QuestCollection",
            column: "id",
            principalTable: "AspNetUsers",
            principalColumn: "id",
            onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
