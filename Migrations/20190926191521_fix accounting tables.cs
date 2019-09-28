using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class fixaccountingtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostSheet",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "CostSheetGroup",
                schema: "Accounting");

            migrationBuilder.AddColumn<long>(
                name: "DestinationAccountId",
                schema: "Accounting",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SourceAccountId",
                schema: "Accounting",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "Accounting",
                table: "Transaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Accounting",
                table: "Plane",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowOveral",
                schema: "Accounting",
                table: "PlanDetail",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Accounting",
                table: "PlanDetail",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentAccountId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    InitialAmount = table.Column<double>(nullable: false),
                    OveralTotal = table.Column<bool>(nullable: false),
                    IsDebit = table.Column<bool>(nullable: false),
                    IsCredit = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_ParentAccountId",
                        column: x => x.ParentAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_DestinationAccountId",
                schema: "Accounting",
                table: "Transaction",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_SourceAccountId",
                schema: "Accounting",
                table: "Transaction",
                column: "SourceAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ParentAccountId",
                table: "Accounts",
                column: "ParentAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Accounts_DestinationAccountId",
                schema: "Accounting",
                table: "Transaction",
                column: "DestinationAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Accounts_SourceAccountId",
                schema: "Accounting",
                table: "Transaction",
                column: "SourceAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Accounts_DestinationAccountId",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Accounts_SourceAccountId",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_DestinationAccountId",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_SourceAccountId",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "DestinationAccountId",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "SourceAccountId",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Accounting",
                table: "Plane");

            migrationBuilder.DropColumn(
                name: "AllowOveral",
                schema: "Accounting",
                table: "PlanDetail");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Accounting",
                table: "PlanDetail");

            migrationBuilder.CreateTable(
                name: "CostSheetGroup",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostSheetGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostSheetGroup_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostSheet",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CostSheetGroupId = table.Column<long>(nullable: true),
                    InitialBalance = table.Column<double>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OveralTotal = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_CostSheet_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostSheet_CostSheetGroupId",
                schema: "Accounting",
                table: "CostSheet",
                column: "CostSheetGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSheet_UserId",
                schema: "Accounting",
                table: "CostSheet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSheetGroup_UserId",
                schema: "Accounting",
                table: "CostSheetGroup",
                column: "UserId");
        }
    }
}
