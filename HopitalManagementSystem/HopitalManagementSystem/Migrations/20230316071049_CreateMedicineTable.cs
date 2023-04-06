using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.Migrations
{
    public partial class CreateMedicineTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "medicine",
                table: "PharmaceInfors");

            migrationBuilder.AddColumn<int>(
                name: "medicineId",
                table: "PharmaceInfors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "PharmaceInfors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    medicineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medicineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    lastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.medicineId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PharmaceInfors_medicineId",
                table: "PharmaceInfors",
                column: "medicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_PharmaceInfors_Medicines_medicineId",
                table: "PharmaceInfors",
                column: "medicineId",
                principalTable: "Medicines",
                principalColumn: "medicineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PharmaceInfors_Medicines_medicineId",
                table: "PharmaceInfors");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_PharmaceInfors_medicineId",
                table: "PharmaceInfors");

            migrationBuilder.DropColumn(
                name: "medicineId",
                table: "PharmaceInfors");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "PharmaceInfors");

            migrationBuilder.AddColumn<string>(
                name: "medicine",
                table: "PharmaceInfors",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
