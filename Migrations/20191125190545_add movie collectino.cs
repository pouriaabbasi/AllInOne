using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class addmoviecollectino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieCollection",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieCollectionDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieCollectionId = table.Column<long>(nullable: false),
                    MovieId = table.Column<long>(nullable: false),
                    Number = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCollectionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieCollectionDetail_MovieCollection_MovieCollectionId",
                        column: x => x.MovieCollectionId,
                        principalTable: "MovieCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCollectionDetail_Movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Movie",
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCollectionDetail_MovieCollectionId",
                table: "MovieCollectionDetail",
                column: "MovieCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCollectionDetail_MovieId",
                table: "MovieCollectionDetail",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCollectionDetail");

            migrationBuilder.DropTable(
                name: "MovieCollection");
        }
    }
}
