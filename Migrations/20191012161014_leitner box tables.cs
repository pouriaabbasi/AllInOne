using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class leitnerboxtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "LeitnerBox");

            migrationBuilder.CreateTable(
                name: "Box",
                schema: "LeitnerBox",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Box", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Box_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "LeitnerBox",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vocabulary = table.Column<string>(maxLength: 100, nullable: false),
                    Meaning = table.Column<string>(maxLength: 100, nullable: false),
                    MainStage = table.Column<byte>(nullable: false),
                    SubStage = table.Column<byte>(nullable: false),
                    FailCount = table.Column<byte>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    BoxId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Box_BoxId",
                        column: x => x.BoxId,
                        principalSchema: "LeitnerBox",
                        principalTable: "Box",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionHistory",
                schema: "LeitnerBox",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    HistoryActionType = table.Column<int>(nullable: false),
                    FromMainStage = table.Column<byte>(nullable: false),
                    ToMainStage = table.Column<byte>(nullable: false),
                    FromSubStage = table.Column<byte>(nullable: false),
                    ToSubStage = table.Column<byte>(nullable: false),
                    QuestionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionHistory_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "LeitnerBox",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Box_UserId",
                schema: "LeitnerBox",
                table: "Box",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_BoxId",
                schema: "LeitnerBox",
                table: "Question",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionHistory_QuestionId",
                schema: "LeitnerBox",
                table: "QuestionHistory",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionHistory",
                schema: "LeitnerBox");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "LeitnerBox");

            migrationBuilder.DropTable(
                name: "Box",
                schema: "LeitnerBox");
        }
    }
}
