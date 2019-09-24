using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class initaccounting1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Accounting");

            migrationBuilder.CreateTable(
                name: "CostSheetGroup",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostSheetGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostSheet",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CostSheetGroupId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    InitialBalance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostSheet_CostSheetGroup_CostSheetGroupId",
                        column: x => x.CostSheetGroupId,
                        principalSchema: "Accounting",
                        principalTable: "CostSheetGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostSheet_CostSheetGroupId",
                schema: "Accounting",
                table: "CostSheet",
                column: "CostSheetGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostSheet",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CostSheetGroup",
                schema: "Accounting");
        }
    }
}
