using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnityBot.Bot.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IshJoylashCount = table.Column<int>(type: "integer", nullable: false),
                    SherikKerakCount = table.Column<int>(type: "integer", nullable: false),
                    RezumeCount = table.Column<int>(type: "integer", nullable: false),
                    UstozkerakCount = table.Column<int>(type: "integer", nullable: false),
                    ShogirtKerakCount = table.Column<int>(type: "integer", nullable: false),
                    LastMessages = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
