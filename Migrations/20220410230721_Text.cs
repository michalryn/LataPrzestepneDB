using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LataPrzestepneDB.Migrations
{
    public partial class Text : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Person");
        }
    }
}
