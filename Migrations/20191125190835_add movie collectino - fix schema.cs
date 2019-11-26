using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class addmoviecollectinofixschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MovieCollectionDetail",
                newName: "MovieCollectionDetail",
                newSchema: "Movie");

            migrationBuilder.RenameTable(
                name: "MovieCollection",
                newName: "MovieCollection",
                newSchema: "Movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MovieCollectionDetail",
                schema: "Movie",
                newName: "MovieCollectionDetail");

            migrationBuilder.RenameTable(
                name: "MovieCollection",
                schema: "Movie",
                newName: "MovieCollection");
        }
    }
}
