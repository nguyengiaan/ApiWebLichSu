using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class up1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catogery",
                columns: table => new
                {
                    ID_CATOGERY = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME_CATOGERY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catogery", x => x.ID_CATOGERY);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME_USER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PASSWORD_USER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID_USER);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    COMNENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    CONTENT_COMMENT = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.COMNENT_ID);
                    table.ForeignKey(
                        name: "FK_Comment_Users_ID_USER",
                        column: x => x.ID_USER,
                        principalTable: "Users",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    ID_HISTORY = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENT = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    DATESUBMIT = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    ID_CATOGERY = table.Column<int>(type: "int", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.ID_HISTORY);
                    table.ForeignKey(
                        name: "FK_History_Catogery_ID_CATOGERY",
                        column: x => x.ID_CATOGERY,
                        principalTable: "Catogery",
                        principalColumn: "ID_CATOGERY",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_History_Users_ID_USER",
                        column: x => x.ID_USER,
                        principalTable: "Users",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    CONTENT_PERMISSION = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PER_ID);
                    table.ForeignKey(
                        name: "FK_Permission_Users_ID_USER",
                        column: x => x.ID_USER,
                        principalTable: "Users",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ID_USER",
                table: "Comment",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_History_ID_CATOGERY",
                table: "History",
                column: "ID_CATOGERY");

            migrationBuilder.CreateIndex(
                name: "IX_History_ID_USER",
                table: "History",
                column: "ID_USER");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_ID_USER",
                table: "Permission",
                column: "ID_USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Catogery");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
