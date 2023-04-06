using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.Migrations
{
    public partial class addLastModifiedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "UrineTestInfors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "SurgeryRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "SurgeryInfors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "PharmaceInfors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "OutPatients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "InPatients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "Discharges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lastModified",
                table: "BloodTestInfors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "UrineTestInfors");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "SurgeryRequest");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "SurgeryInfors");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "PharmaceInfors");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "OutPatients");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "InPatients");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "Discharges");

            migrationBuilder.DropColumn(
                name: "lastModified",
                table: "BloodTestInfors");
        }
    }
}
