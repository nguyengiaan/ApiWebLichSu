using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                           name: "Answerid_Answer",
                           table: "Quest",
                           nullable: true,
                           maxLength: 255);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quest_AnswerQuest_Answerid_Answer",
                table: "Quest");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Quest_Answerid_Answer",
                table: "Quest");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "QuestCollection");

            migrationBuilder.DropColumn(
                name: "Answerid_Answer",
                table: "Quest");

            migrationBuilder.AddColumn<int>(
                name: "AnswerQuestid_Answer",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Question_AnswerQuestid_Answer",
                table: "Question",
                column: "AnswerQuestid_Answer");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuest_Id_quest",
                table: "AnswerQuest",
                column: "Id_quest",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerQuest_Quest_Id_quest",
                table: "AnswerQuest",
                column: "Id_quest",
                principalTable: "Quest",
                principalColumn: "Id_quest",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AnswerQuest_AnswerQuestid_Answer",
                table: "Question",
                column: "AnswerQuestid_Answer",
                principalTable: "AnswerQuest",
                principalColumn: "id_Answer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
