﻿// <auto-generated />
using System;
using HospitalManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalManagementSystem.Migrations
{
    [DbContext(typeof(HospitalManagermentContext))]
    [Migration("20230403033111_removeRequiredAddress")]
    partial class removeRequiredAddress
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("bloodGroup")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<float>("bloodsugar")
                        .HasColumnType("real");

                    b.Property<string>("description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("");

                    b.Property<float>("haemoglobin")
                        .HasColumnType("real");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<float>("sacid")
                        .HasColumnType("real");

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

                    b.Property<DateTime>("lastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("dateIn")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("dateOut")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("familyPhone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("staffId")
                        .HasColumnType("int");

                    b.Property<string>("symptoms")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("wardNum")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("inPatientId");

                    b.HasIndex("patientId");

                    b.HasIndex("staffId");

                    b.ToTable("InPatients");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.Medicine", b =>
                {
                    b.Property<int>("medicineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("medicineName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("medicineId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("HospitalManagementSystem.Models.OutPatient", b =>
                {
                    b.Property<int>("outPatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("department")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("familyPhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("onDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

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
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("age")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("occupation")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.Property<string>("patientName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("medicineId")
                        .HasColumnType("int");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("pharmacyInforId");

                    b.HasIndex("medicineId");

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
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("age")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastAccess")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("specialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("staffName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("result")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("staffId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("surgeryDate")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("surgeryTpye")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasDefaultValue("");

                    b.Property<float>("glucose")
                        .HasColumnType("real");

                    b.Property<bool>("isDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("lastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("mediclatestype")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("odor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<string>("specificgravity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                    b.HasOne("HospitalManagementSystem.Models.Medicine", "medicine")
                        .WithMany("pharmacyInfors")
                        .HasForeignKey("medicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystem.Models.Patient", "patient")
                        .WithMany("pharmacyInfors")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medicine");

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

            modelBuilder.Entity("HospitalManagementSystem.Models.Medicine", b =>
                {
                    b.Navigation("pharmacyInfors");
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