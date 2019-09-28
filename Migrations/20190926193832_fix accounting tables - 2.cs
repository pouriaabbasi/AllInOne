using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class fixaccountingtables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "Accounting",
                table: "Account",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserId",
                schema: "Accounting",
                table: "Account",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_UserId",
                schema: "Accounting",
                table: "Account",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_User_UserId",
                schema: "Accounting",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_UserId",
                schema: "Accounting",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Accounting",
                table: "Account");
        }
    }
}
