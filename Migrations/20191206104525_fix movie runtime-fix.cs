using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class fixmovieruntimefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Runtime",
                schema: "Movie",
                table: "Movie",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Runtime",
                schema: "Movie",
                table: "Movie");
        }
    }
}
