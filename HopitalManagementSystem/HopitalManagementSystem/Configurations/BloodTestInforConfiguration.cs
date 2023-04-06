using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class BloodTestInforConfiguration : IEntityTypeConfiguration<BloodTestInfor>
    {
        public void Configure(EntityTypeBuilder<BloodTestInfor> builder)
        {
            builder.ToTable("BloodTestInfors");
            //primary key
            builder.HasKey(x => x.bloodTestId);
            //attribute
            builder.Property(x => x.Mediclatestype).IsRequired().HasMaxLength(100);
            builder.Property(x => x.bloodGroup).IsRequired().HasMaxLength(10);
            builder.Property(x => x.haemoglobin).IsRequired();
            builder.Property(x => x.bloodsugar).IsRequired();
            builder.Property(x => x.sacid).IsRequired();
            builder.Property(x => x.description).HasDefaultValue("").HasMaxLength(500);
            builder.Property(x => x.lastModified).IsRequired().HasDefaultValue(new DateTime());

            //builder.Property(x => x.isDelete).HasDefaultValue(false);
            //foreign key
            builder.HasOne(x => x.patient).WithMany(x => x.bloodTestInfors).HasForeignKey(x => x.patientId);
        }
    }
}
