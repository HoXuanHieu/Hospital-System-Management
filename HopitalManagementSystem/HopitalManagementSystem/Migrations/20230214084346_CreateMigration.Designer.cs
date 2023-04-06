﻿// <auto-generated />
using HospitalManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalManagementSystem.Migrations
{
    [DbContext(typeof(HospitalManagermentContext))]
    [Migration("20230214084346_CreateMigration")]
    partial class CreateMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HospitalManagementSystem.Models.BloodTestInfor", b =>
                {
                    b.Property<int>("bloodTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mediclatestype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bloodGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bloodsugar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("haemoglobin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<string>("sacid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bloodTestId");

                    b.HasIndex("patientId");

                    b.ToTable("BloodTestInfors");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.Discharge", b =>
                {
                    b.Property<int>("dischargeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dischargeDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<string>("joinDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.HasKey("dischargeId");

                    b.HasIndex("patientId");

                    b.ToTable("Discharges");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.InPatient", b =>
                {
                    b.Property<int>("inPatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("bedNum")
                        .HasColumnType("int");

                    b.Property<string>("dateIn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dateOut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("familyPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("staffId")
                        .HasColumnType("int");

                    b.Property<string>("symptoms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("wardNum")
                        .HasColumnType("int");

                    b.HasKey("inPatientId");

                    b.HasIndex("patientId");

                    b.HasIndex("staffId");

                    b.ToTable("InPatients");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.OutPatient", b =>
                {
                    b.Property<int>("outPatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("familyPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<string>("onDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("staffId")
                        .HasColumnType("int");

                    b.HasKey("outPatientId");

                    b.HasIndex("patientId");

                    b.HasIndex("staffId");

                    b.ToTable("OutPatients");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.Patient", b =>
                {
                    b.Property<int>("patientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<string>("occupation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("patientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("patientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.PharmacyInfor", b =>
                {
                    b.Property<int>("pharmacyInforId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<string>("medicine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pharmacyInforId");

                    b.HasIndex("patientId");

                    b.ToTable("PharmaceInfors");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.Staff", b =>
                {
                    b.Property<int>("staffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("specialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("staffName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("staffId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.SurgeryInfor", b =>
                {
                    b.Property<int>("surgeryInforId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<string>("result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("surgeryRequestId")
                        .HasColumnType("int");

                    b.HasKey("surgeryInforId");

                    b.HasIndex("surgeryRequestId")
                        .IsUnique();

                    b.ToTable("SurgeryInfors");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.SurgeryRequest", b =>
                {
                    b.Property<int>("surgeryRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("staffId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surgeryDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surgeryTpye")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("surgeryRequestId");

                    b.HasIndex("patientId");

                    b.HasIndex("staffId");

                    b.ToTable("SurgeryRequest");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.UrineTestInfor", b =>
                {
                    b.Property<int>("urineTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("calrity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("glucose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<string>("mediclatestype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("odor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<string>("specificgravity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("urineTestId");

                    b.HasIndex("patientId");

                    b.ToTable("UrineTestInfors");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.BloodTestInfor", b =>
                {
                    b.HasOne("HospitalManagementSystem.Models.Patient", "patient")
                        .WithMany("bloodTestInfors")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patient");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.Discharge", b =>
                {
                    b.HasOne("HospitalManagementSystem.Models.Patient", "patient")
                        .WithMany("discharges")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patient");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.InPatient", b =>
                {
                    b.HasOne("HospitalManagementSystem.Models.Patient", "patient")
                        .WithMany("inPatients")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Models.Staff", "staff")
                        .WithMany("inPatients")
                        .HasForeignKey("staffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patient");

                    b.Navigation("staff");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.OutPatient", b =>
                {
                    b.HasOne("HospitalManagementSystem.Models.Patient", "patient")
                        .WithMany("outPatients")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Models.Staff", "staff")
                        .WithMany("outPatients")
                        .HasForeignKey("staffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patient");

                    b.Navigation("staff");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.PharmacyInfor", b =>
                {
                    b.HasOne("HospitalManagementSystem.Models.Patient", "patient")
                        .WithMany("pharmacyInfors")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patient");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.SurgeryInfor", b =>
                {
                    b.HasOne("HospitalManagementSystem.Models.SurgeryRequest", "surgeryRequest")
                        .WithOne("surgeryInfor")
                        .HasForeignKey("HospitalManagementSystem.Models.SurgeryInfor", "surgeryRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("surgeryRequest");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.SurgeryRequest", b =>
                {
                    b.HasOne("HospitalManagementSystem.Models.Patient", "patient")
                        .WithMany("surgeryRequests")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Models.Staff", "staff")
                        .WithMany("surgeryRequests")
                        .HasForeignKey("staffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patient");

                    b.Navigation("staff");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.UrineTestInfor", b =>
                {
                    b.HasOne("HospitalManagementSystem.Models.Patient", "patient")
                        .WithMany("urineTestInfors")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patient");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.Patient", b =>
                {
                    b.Navigation("bloodTestInfors");

                    b.Navigation("discharges");

                    b.Navigation("inPatients");

                    b.Navigation("outPatients");

                    b.Navigation("pharmacyInfors");

                    b.Navigation("surgeryRequests");

                    b.Navigation("urineTestInfors");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.Staff", b =>
                {
                    b.Navigation("inPatients");

                    b.Navigation("outPatients");

                    b.Navigation("surgeryRequests");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.SurgeryRequest", b =>
                {
                    b.Navigation("surgeryInfor");
                });
#pragma warning restore 612, 618
        }
    }
}
