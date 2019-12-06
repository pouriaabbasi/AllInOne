using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class addusertomoviecollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "Movie",
                table: "MovieCollection",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieCollection_UserId",
                schema: "Movie",
                table: "MovieCollection",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCollection_User_UserId",
                schema: "Movie",
                table: "MovieCollection",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCollection_User_UserId",
                schema: "Movie",
                table: "MovieCollection");

            migrationBuilder.DropIndex(
                name: "IX_MovieCollection_UserId",
                schema: "Movie",
                table: "MovieCollection");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Movie",
                table: "MovieCollection");
        }
    }
}
