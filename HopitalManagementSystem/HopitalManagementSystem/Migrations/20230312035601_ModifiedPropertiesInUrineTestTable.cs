using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.Migrations
{
    public partial class ModifiedPropertiesInUrineTestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "glucose",
                table: "UrineTestInfors",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "glucose",
                table: "UrineTestInfors",
                type: "nvarchar(100)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
