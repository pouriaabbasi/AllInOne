using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class leitnerboxfixtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                schema: "LeitnerBox",
                table: "Question",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                schema: "LeitnerBox",
                table: "Question",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                schema: "LeitnerBox",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "IsPending",
                schema: "LeitnerBox",
                table: "Question");
        }
    }
}
