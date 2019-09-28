using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class fixaccountingtables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Accounts_ParentAccountId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Accounts_DestinationAccountId",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Accounts_SourceAccountId",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account",
                newSchema: "Accounting");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_ParentAccountId",
                schema: "Accounting",
                table: "Account",
                newName: "IX_Account_ParentAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                schema: "Accounting",
                table: "Account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Account_ParentAccountId",
                schema: "Accounting",
                table: "Account",
                column: "ParentAccountId",
                principalSchema: "Accounting",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_DestinationAccountId",
                schema: "Accounting",
                table: "Transaction",
                column: "DestinationAccountId",
                principalSchema: "Accounting",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_SourceAccountId",
                schema: "Accounting",
                table: "Transaction",
                column: "SourceAccountId",
                principalSchema: "Accounting",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Account_ParentAccountId",
                schema: "Accounting",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_DestinationAccountId",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_SourceAccountId",
                schema: "Accounting",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                schema: "Accounting",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                schema: "Accounting",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Account_ParentAccountId",
                table: "Accounts",
                newName: "IX_Accounts_ParentAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Accounts_ParentAccountId",
                table: "Accounts",
                column: "ParentAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
