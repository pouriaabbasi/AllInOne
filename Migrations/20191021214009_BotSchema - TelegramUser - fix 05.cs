using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllInOne.Migrations
{
    public partial class BotSchemaTelegramUserfix05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TelegramUser",
                schema: "Bot",
                table: "TelegramUser");

            migrationBuilder.DropColumn(
                name: "tempId",
                schema: "Bot",
                table: "TelegramUser");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                schema: "Bot",
                table: "TelegramUser",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TelegramUser",
                schema: "Bot",
                table: "TelegramUser",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TelegramUser",
                schema: "Bot",
                table: "TelegramUser");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Bot",
                table: "TelegramUser");

            migrationBuilder.AddColumn<int>(
                name: "tempId",
                schema: "Bot",
                table: "TelegramUser",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TelegramUser",
                schema: "Bot",
                table: "TelegramUser",
                column: "tempId");
        }
    }
}
