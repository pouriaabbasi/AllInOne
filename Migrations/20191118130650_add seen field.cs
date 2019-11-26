using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class addseenfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                schema: "Movie",
                table: "Movie",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                schema: "Movie",
                table: "Movie");
        }
    }
}
