using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class úp6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                           name: "ApplicationUserId",
                           table: "History",
                           nullable: true,
                           maxLength: 255);
            migrationBuilder.AddColumn<string>(
                 name: "UsersID_USER",
                 table: "History",
                 nullable: true,
                 maxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Users_UsersID_USER",
                table: "History");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "UsersID_USER",
                table: "History",
                newName: "USERSID_USER");

            migrationBuilder.RenameIndex(
                name: "IX_History_UsersID_USER",
                table: "History",
                newName: "IX_History_USERSID_USER");

            migrationBuilder.AlterColumn<int>(
                name: "USERSID_USER",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATESUBMIT",
                table: "History",
                type: "datetime2",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ID_USER",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Users_USERSID_USER",
                table: "History",
                column: "USERSID_USER",
                principalTable: "Users",
                principalColumn: "ID_USER",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
