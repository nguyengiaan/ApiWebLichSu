using ApiWebLichSu.Model;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class drop_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Comment_Users_ID_USER", "Comment");
            migrationBuilder.AddColumn<string>
            (
                 name: "Id",
                 table: "Comment",
                 nullable: true,
                 maxLength: 450
            );
            migrationBuilder.AddForeignKey(
            name: "FK_Comment_Users_ID_USER",
            table: "Comment",
            column: "id",
            principalTable: "AspNetUsers",
            principalColumn: "id",
            onDelete: ReferentialAction.Restrict
         );
           migrationBuilder.DropForeignKey("FK_History_Users_ID_USER", "History");
            migrationBuilder.AddColumn<string>
      (
           name: "Id",
           table: "History",
           nullable: true,
           maxLength: 450
      );
            migrationBuilder.AddForeignKey(
           name: "FK_History_Users_ID_USER",
           table: "History",
           column: "Id",
           principalTable: "AspNetUsers",
           principalColumn: "Id",
           onDelete: ReferentialAction.Restrict
        );
            migrationBuilder.DropForeignKey("FK_Permission_Users_ID_USER", "Permission");
            migrationBuilder.DropTable("Permission");
            migrationBuilder.DropForeignKey("FK_Quest_Users_ID_USER", "Quest");
            migrationBuilder.AddColumn<string>
            (
                 name: "Id",
                 table: "Quest",
                 nullable: true,
                 maxLength: 450
            );
            migrationBuilder.AddForeignKey(
            name: "FK_Quest_Users_ID_USER",
            table: "Quest",
            column: "Id",
            principalTable: "AspNetUsers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict
            );
            migrationBuilder.DropTable("Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
