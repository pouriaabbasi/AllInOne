using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.EnsureSchema(
                name: "Todo");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Todo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "List",
                schema: "Todo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    GroupId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.Id);
                    table.ForeignKey(
                        name: "FK_List_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Todo",
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_List_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_UserId",
                schema: "Todo",
                table: "Group",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_List_GroupId",
                schema: "Todo",
                table: "List",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_List_UserId",
                schema: "Todo",
                table: "List",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "List",
                schema: "Todo");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "Todo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Security");
        }
    }
}
