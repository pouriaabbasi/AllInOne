using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class movieschematablesinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Movie");

            migrationBuilder.CreateTable(
                name: "Cast",
                schema: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                schema: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                schema: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                schema: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Year = table.Column<string>(maxLength: 10, nullable: true),
                    Rated = table.Column<string>(maxLength: 20, nullable: true),
                    Released = table.Column<string>(maxLength: 20, nullable: true),
                    Plot = table.Column<string>(maxLength: 1000, nullable: true),
                    Awards = table.Column<string>(maxLength: 200, nullable: true),
                    Poster = table.Column<string>(maxLength: 100, nullable: true),
                    Metascore = table.Column<string>(maxLength: 50, nullable: true),
                    ImdbRating = table.Column<string>(maxLength: 50, nullable: true),
                    ImdbVotes = table.Column<string>(maxLength: 50, nullable: true),
                    ImdbId = table.Column<string>(maxLength: 20, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    DvdReleaseDate = table.Column<string>(maxLength: 20, nullable: true),
                    BoxOffice = table.Column<string>(maxLength: 20, nullable: true),
                    Production = table.Column<string>(maxLength: 50, nullable: true),
                    Website = table.Column<string>(maxLength: 100, nullable: true),
                    TotalSeasons = table.Column<string>(maxLength: 10, nullable: true),
                    SeriesId = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCast",
                schema: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<long>(nullable: false),
                    CastId = table.Column<long>(nullable: false),
                    CastType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieCast_Cast_CastId",
                        column: x => x.CastId,
                        principalSchema: "Movie",
                        principalTable: "Cast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCast_Movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Movie",
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCountry",
                schema: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<long>(nullable: false),
                    CountryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCountry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieCountry_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Movie",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCountry_Movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Movie",
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                schema: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<long>(nullable: false),
                    GenreId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "Movie",
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Movie",
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLanguage",
                schema: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<long>(nullable: false),
                    LanguageId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Movie",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLanguage_Movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Movie",
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                schema: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<long>(nullable: false),
                    SourceName = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Movie_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Movie",
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_UserId",
                schema: "Movie",
                table: "Movie",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_CastId",
                schema: "Movie",
                table: "MovieCast",
                column: "CastId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_MovieId",
                schema: "Movie",
                table: "MovieCast",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCountry_CountryId",
                schema: "Movie",
                table: "MovieCountry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCountry_MovieId",
                schema: "Movie",
                table: "MovieCountry",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                schema: "Movie",
                table: "MovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MovieId",
                schema: "Movie",
                table: "MovieGenre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguage_LanguageId",
                schema: "Movie",
                table: "MovieLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLanguage_MovieId",
                schema: "Movie",
                table: "MovieLanguage",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_MovieId",
                schema: "Movie",
                table: "Rating",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCast",
                schema: "Movie");

            migrationBuilder.DropTable(
                name: "MovieCountry",
                schema: "Movie");

            migrationBuilder.DropTable(
                name: "MovieGenre",
                schema: "Movie");

            migrationBuilder.DropTable(
                name: "MovieLanguage",
                schema: "Movie");

            migrationBuilder.DropTable(
                name: "Rating",
                schema: "Movie");

            migrationBuilder.DropTable(
                name: "Cast",
                schema: "Movie");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Movie");

            migrationBuilder.DropTable(
                name: "Genre",
                schema: "Movie");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "Movie");

            migrationBuilder.DropTable(
                name: "Movie",
                schema: "Movie");
        }
    }
}
