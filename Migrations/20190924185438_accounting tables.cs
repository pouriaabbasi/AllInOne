using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class accountingtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "Accounting",
                table: "CostSheetGroup",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "OveralTotal",
                schema: "Accounting",
                table: "CostSheet",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "Accounting",
                table: "CostSheet",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Plane",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plane", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plane_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanDetail",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Achieve = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDetail_Plane_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "Accounting",
                        principalTable: "Plane",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "Accounting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    PlanDetailId = table.Column<long>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_PlanDetail_PlanDetailId",
                        column: x => x.PlanDetailId,
                        principalSchema: "Accounting",
                        principalTable: "PlanDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostSheetGroup_UserId",
                schema: "Accounting",
                table: "CostSheetGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostSheet_UserId",
                schema: "Accounting",
                table: "CostSheet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_PlanId",
                schema: "Accounting",
                table: "PlanDetail",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plane_UserId",
                schema: "Accounting",
                table: "Plane",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PlanDetailId",
                schema: "Accounting",
                table: "Transaction",
                column: "PlanDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                schema: "Accounting",
                table: "Transaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostSheet_User_UserId",
                schema: "Accounting",
                table: "CostSheet",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostSheetGroup_User_UserId",
                schema: "Accounting",
                table: "CostSheetGroup",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostSheet_User_UserId",
                schema: "Accounting",
                table: "CostSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_CostSheetGroup_User_UserId",
                schema: "Accounting",
                table: "CostSheetGroup");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "PlanDetail",
                schema: "Accounting");

            migrationBuilder.DropTable(
                name: "Plane",
                schema: "Accounting");

            migrationBuilder.DropIndex(
                name: "IX_CostSheetGroup_UserId",
                schema: "Accounting",
                table: "CostSheetGroup");

            migrationBuilder.DropIndex(
                name: "IX_CostSheet_UserId",
                schema: "Accounting",
                table: "CostSheet");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Accounting",
                table: "CostSheetGroup");

            migrationBuilder.DropColumn(
                name: "OveralTotal",
                schema: "Accounting",
                table: "CostSheet");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Accounting",
                table: "CostSheet");
        }
    }
}
