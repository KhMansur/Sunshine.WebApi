using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sunshine.Data.Migrations
{
    /// <inheritdoc />
    public partial class correctNameMistakes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPayments_TeachersPayment_TeacherPaymentId",
                table: "StudentPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersPayment_Teachers_TeacherId",
                table: "TeachersPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeachersPayment",
                table: "TeachersPayment");

            migrationBuilder.RenameTable(
                name: "TeachersPayment",
                newName: "TeacherPayments");

            migrationBuilder.RenameIndex(
                name: "IX_TeachersPayment_TeacherId",
                table: "TeacherPayments",
                newName: "IX_TeacherPayments_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherPayments",
                table: "TeacherPayments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPayments_TeacherPayments_TeacherPaymentId",
                table: "StudentPayments",
                column: "TeacherPaymentId",
                principalTable: "TeacherPayments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPayments_Teachers_TeacherId",
                table: "TeacherPayments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPayments_TeacherPayments_TeacherPaymentId",
                table: "StudentPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPayments_Teachers_TeacherId",
                table: "TeacherPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherPayments",
                table: "TeacherPayments");

            migrationBuilder.RenameTable(
                name: "TeacherPayments",
                newName: "TeachersPayment");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherPayments_TeacherId",
                table: "TeachersPayment",
                newName: "IX_TeachersPayment_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeachersPayment",
                table: "TeachersPayment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPayments_TeachersPayment_TeacherPaymentId",
                table: "StudentPayments",
                column: "TeacherPaymentId",
                principalTable: "TeachersPayment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersPayment_Teachers_TeacherId",
                table: "TeachersPayment",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
