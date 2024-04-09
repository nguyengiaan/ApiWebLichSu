using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    Id_quest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest", x => x.Id_quest);
                    table.ForeignKey(
                        name: "FK_Quest_Users_ID_USER",
                        column: x => x.ID_USER,
                        principalTable: "Users",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerQuest",
                columns: table => new
                {
                    id_Answer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Id_quest = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuest", x => x.id_Answer);
                    table.ForeignKey(
                        name: "FK_AnswerQuest_Quest_Id_quest",
                        column: x => x.Id_quest,
                        principalTable: "Quest",
                        principalColumn: "Id_quest",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id_Question = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question_quest = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Id_quest = table.Column<int>(type: "int", nullable: false),
                    AnswerQuestid_Answer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id_Question);
                    table.ForeignKey(
                        name: "FK_Question_AnswerQuest_AnswerQuestid_Answer",
                        column: x => x.AnswerQuestid_Answer,
                        principalTable: "AnswerQuest",
                        principalColumn: "id_Answer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Quest_Id_quest",
                        column: x => x.Id_quest,
                        principalTable: "Quest",
                        principalColumn: "Id_quest",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuest_Id_quest",
                table: "AnswerQuest",
                column: "Id_quest",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quest_ID_USER",
                table: "Quest",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_Question_AnswerQuestid_Answer",
                table: "Question",
                column: "AnswerQuestid_Answer");

            migrationBuilder.CreateIndex(
                name: "IX_Question_Id_quest",
                table: "Question",
                column: "Id_quest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "AnswerQuest");

            migrationBuilder.DropTable(
                name: "Quest");
        }
    }
}
