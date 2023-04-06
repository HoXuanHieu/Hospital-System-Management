using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            //primary key
            builder.HasKey(x => x.patientId);
            //attribute
            builder.Property(x => x.patientName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.age).IsRequired().HasMaxLength(10);
            builder.Property(x => x.phoneNumber).IsRequired().HasMaxLength(12);
            builder.Property(x => x.gender).IsRequired().HasMaxLength(10);
            builder.Property(x => x.address).IsRequired().HasMaxLength(500);
            builder.Property(x => x.occupation).HasDefaultValue("").HasMaxLength(100);
            builder.Property(x => x.lastModified).IsRequired().HasDefaultValue(new DateTime());

        }
    }
}
