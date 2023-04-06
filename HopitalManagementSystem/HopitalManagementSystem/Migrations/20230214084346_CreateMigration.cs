using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.Migrations
{
    public partial class CreateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    patientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    occupation = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.patientId);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    staffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.staffId);
                });

            migrationBuilder.CreateTable(
                name: "BloodTestInfors",
                columns: table => new
                {
                    bloodTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mediclatestype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    haemoglobin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bloodsugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sacid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTestInfors", x => x.bloodTestId);
                    table.ForeignKey(
                        name: "FK_BloodTestInfors_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discharges",
                columns: table => new
                {
                    dischargeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    joinDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dischargeDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discharges", x => x.dischargeId);
                    table.ForeignKey(
                        name: "FK_Discharges_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PharmaceInfors",
                columns: table => new
                {
                    pharmacyInforId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medicine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaceInfors", x => x.pharmacyInforId);
                    table.ForeignKey(
                        name: "FK_PharmaceInfors_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UrineTestInfors",
                columns: table => new
                {
                    urineTestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mediclatestype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calrity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    odor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    specificgravity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    glucose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrineTestInfors", x => x.urineTestId);
                    table.ForeignKey(
                        name: "FK_UrineTestInfors_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InPatients",
                columns: table => new
                {
                    inPatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    familyPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wardNum = table.Column<int>(type: "int", nullable: false),
                    bedNum = table.Column<int>(type: "int", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    staffId = table.Column<int>(type: "int", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InPatients", x => x.inPatientId);
                    table.ForeignKey(
                        name: "FK_InPatients_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InPatients_Staffs_staffId",
                        column: x => x.staffId,
                        principalTable: "Staffs",
                        principalColumn: "staffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutPatients",
                columns: table => new
                {
                    outPatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    familyPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    onDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    staffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutPatients", x => x.outPatientId);
                    table.ForeignKey(
                        name: "FK_OutPatients_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutPatients_Staffs_staffId",
                        column: x => x.staffId,
                        principalTable: "Staffs",
                        principalColumn: "staffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurgeryRequest",
                columns: table => new
                {
                    surgeryRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    surgeryTpye = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surgeryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    staffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgeryRequest", x => x.surgeryRequestId);
                    table.ForeignKey(
                        name: "FK_SurgeryRequest_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurgeryRequest_Staffs_staffId",
                        column: x => x.staffId,
                        principalTable: "Staffs",
                        principalColumn: "staffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurgeryInfors",
                columns: table => new
                {
                    surgeryInforId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: ""),
                    isDelete = table.Column<bool>(type: "bit", nullable: false),
                    surgeryRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgeryInfors", x => x.surgeryInforId);
                    table.ForeignKey(
                        name: "FK_SurgeryInfors_SurgeryRequest_surgeryRequestId",
                        column: x => x.surgeryRequestId,
                        principalTable: "SurgeryRequest",
                        principalColumn: "surgeryRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodTestInfors_patientId",
                table: "BloodTestInfors",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Discharges_patientId",
                table: "Discharges",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_InPatients_patientId",
                table: "InPatients",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_InPatients_staffId",
                table: "InPatients",
                column: "staffId");

            migrationBuilder.CreateIndex(
                name: "IX_OutPatients_patientId",
                table: "OutPatients",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_OutPatients_staffId",
                table: "OutPatients",
                column: "staffId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmaceInfors_patientId",
                table: "PharmaceInfors",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryInfors_surgeryRequestId",
                table: "SurgeryInfors",
                column: "surgeryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryRequest_patientId",
                table: "SurgeryRequest",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryRequest_staffId",
                table: "SurgeryRequest",
                column: "staffId");

            migrationBuilder.CreateIndex(
                name: "IX_UrineTestInfors_patientId",
                table: "UrineTestInfors",
                column: "patientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTestInfors");

            migrationBuilder.DropTable(
                name: "Discharges");

            migrationBuilder.DropTable(
                name: "InPatients");

            migrationBuilder.DropTable(
                name: "OutPatients");

            migrationBuilder.DropTable(
                name: "PharmaceInfors");

            migrationBuilder.DropTable(
                name: "SurgeryInfors");

            migrationBuilder.DropTable(
                name: "UrineTestInfors");

            migrationBuilder.DropTable(
                name: "SurgeryRequest");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
