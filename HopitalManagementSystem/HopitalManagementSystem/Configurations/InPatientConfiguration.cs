using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class InPatientConfiguration : IEntityTypeConfiguration<InPatient>
    {
        public void Configure(EntityTypeBuilder<InPatient> builder)
        {
            builder.ToTable("InPatients");
            //primary key
            builder.HasKey(x => x.inPatientId);
            //attribute
            builder.Property(x => x.familyPhone).IsRequired().HasMaxLength(11);
            builder.Property(x => x.dateIn).IsRequired().HasMaxLength(20);
            builder.Property(x => x.dateOut).IsRequired().HasMaxLength(20);
            builder.Property(x => x.symptoms).IsRequired().HasMaxLength(500);
            builder.Property(x => x.wardNum).IsRequired().HasMaxLength(10);
            builder.Property(x => x.bedNum).IsRequired().HasMaxLength(10);
            builder.Property(x => x.department).IsRequired().HasMaxLength(100);
            builder.Property(x => x.lastModified).IsRequired().HasDefaultValue(new DateTime());

            //foreign key
            builder.HasOne(x => x.patient).WithMany(x => x.inPatients).HasForeignKey(x => x.patientId);
            builder.HasOne(x => x.staff).WithMany(x => x.inPatients).HasForeignKey(x => x.staffId);

        }
    }
}
