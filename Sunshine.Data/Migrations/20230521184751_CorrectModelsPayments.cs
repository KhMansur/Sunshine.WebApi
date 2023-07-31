using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunshine.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectModelsPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerDays",
                table: "StudentPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Groups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attendences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaidDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendences_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendences_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendencesPerDay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttendenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendencesPerDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendencesPerDay_Attendences_AttendenceId",
                        column: x => x.AttendenceId,
                        principalTable: "Attendences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2e6c2d6a-dc83-4bab-b7a9-98ae31ee16bb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f1b5450-df19-4a7a-a70f-7bc386732151", "AQAAAAIAAYagAAAAEIbAUbiFs1F999X+4YsvHXRZJpCodE8I4DN/DqMZInySj8Zu5i5oKmpa597Apm2BmA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_GroupId",
                table: "Attendences",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_StudentId",
                table: "Attendences",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendencesPerDay_AttendenceId",
                table: "AttendencesPerDay",
                column: "AttendenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendencesPerDay");

            migrationBuilder.DropTable(
                name: "Attendences");

            migrationBuilder.DropColumn(
                name: "PerDays",
                table: "StudentPayments");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2e6c2d6a-dc83-4bab-b7a9-98ae31ee16bb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5582705b-f746-4a74-b7fd-bb977a53430b", "AQAAAAIAAYagAAAAENGz6+7m3iX5TJHyFSKCnbt1c8w2kf0uhy7B8lU3ElGznlC4zA6ly609uU5SevWC0A==" });
        }
    }
}
