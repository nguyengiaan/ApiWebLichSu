using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class addmigrationdropkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          //  migrationBuilder.DropForeignKey(
              //  name: "FK_Quest_QuestCollection_questCollectionid_questcollection",
             //   table: "Quest");

         //   migrationBuilder.DropIndex(
          //      name: "IX_Quest_questCollectionid_questcollection",
           //     table: "Quest");

           // migrationBuilder.DropColumn(
           //     name: "questCollectionid_questcollection",
            //    table: "Quest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "questCollectionid_questcollection",
                table: "Quest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quest_questCollectionid_questcollection",
                table: "Quest",
                column: "questCollectionid_questcollection");

            migrationBuilder.AddForeignKey(
                name: "FK_Quest_QuestCollection_questCollectionid_questcollection",
                table: "Quest",
                column: "questCollectionid_questcollection",
                principalTable: "QuestCollection",
                principalColumn: "id_questcollection",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
