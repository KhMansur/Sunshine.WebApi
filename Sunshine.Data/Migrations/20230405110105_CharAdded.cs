using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunshine.Data.Migrations
{
    /// <inheritdoc />
    public partial class CharAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecieverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2e6c2d6a-dc83-4bab-b7a9-98ae31ee16bb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5582705b-f746-4a74-b7fd-bb977a53430b", "AQAAAAIAAYagAAAAENGz6+7m3iX5TJHyFSKCnbt1c8w2kf0uhy7B8lU3ElGznlC4zA6ly609uU5SevWC0A==" });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2e6c2d6a-dc83-4bab-b7a9-98ae31ee16bb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f54a43a-c8f3-4408-aa45-ca3fbab9ef85", "AQAAAAIAAYagAAAAEMrwFbZdXtDj1w2RW/8PZrLecGv6OOjFaTCyZNjm9a9OSi3KY8ZMDBsB1BSD53/9AQ==" });
        }
    }
}
