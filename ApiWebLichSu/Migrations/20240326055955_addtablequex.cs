using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWebLichSu.Migrations
{
    public partial class addtablequex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestCollection",
                columns: table => new
                {
                    id_questcollection = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    title_collection = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    image_quest = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestCollection", x => x.id_questcollection);  
                });
            migrationBuilder.AddColumn<int>("id_questcollection", "Quest",
                                  nullable: true, defaultValue: null);
            migrationBuilder.AddForeignKey(
                    name: "FK_QuestCollection",  // Optional: A name for the foreign key constraint
                    table: "Quest",      // The table that contains the foreign key column(s)
                    column: "id_questcollection",    // The column(s) in the table that define the foreign key
                    principalTable: "QuestCollection",  // The table that the foreign key references
                    principalColumn: "id_questcollection", // The column(s) in the related table that are referenced
                    onDelete: ReferentialAction.Restrict, // Optional: Action to take when a referenced row is deleted (default: Restrict)
                    onUpdate: ReferentialAction.Cascade  // Optional: Action to take when a referenced row is updated (default: No Action)
            );
}
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
