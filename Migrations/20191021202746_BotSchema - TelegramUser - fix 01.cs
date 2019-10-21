using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class BotSchemaTelegramUserfix01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelegramUser_User_UserId",
                table: "TelegramUser");

            migrationBuilder.EnsureSchema(
                name: "Bot");

            migrationBuilder.RenameTable(
                name: "TelegramUser",
                newName: "TelegramUser",
                newSchema: "Bot");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "Bot",
                table: "TelegramUser",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "Bot",
                table: "TelegramUser",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Bot",
                table: "TelegramUser",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageCode",
                schema: "Bot",
                table: "TelegramUser",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Bot",
                table: "TelegramUser",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TelegramUser_User_UserId",
                schema: "Bot",
                table: "TelegramUser",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TelegramUser_User_UserId",
                schema: "Bot",
                table: "TelegramUser");

            migrationBuilder.RenameTable(
                name: "TelegramUser",
                schema: "Bot",
                newName: "TelegramUser");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "TelegramUser",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "TelegramUser",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "TelegramUser",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageCode",
                table: "TelegramUser",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "TelegramUser",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TelegramUser_User_UserId",
                table: "TelegramUser",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
