using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class OutPatientConfiguration : IEntityTypeConfiguration<OutPatient>
    {
        public void Configure(EntityTypeBuilder<OutPatient> builder)
        {
            builder.ToTable("OutPatients");
            //key
            builder.HasKey(x => x.outPatientId);
            //attribute
            builder.Property(x => x.familyPhone).IsRequired().HasMaxLength(10);
            builder.Property(x => x.onDate).IsRequired().HasMaxLength(20);
            builder.Property(x => x.department).IsRequired().HasMaxLength(500);
            builder.Property(x => x.lastModified).IsRequired().HasDefaultValue(new DateTime());

            //foreign key
            builder.HasOne(x => x.patient).WithMany(x => x.outPatients).HasForeignKey(x => x.patientId);
            builder.HasOne(x => x.staff).WithMany(x => x.outPatients).HasForeignKey(x => x.staffId);
        }
    }
}
