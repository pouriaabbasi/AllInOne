using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class fixpostercolumnlenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                schema: "Movie",
                table: "Movie",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Poster",
                schema: "Movie",
                table: "Movie",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
