using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class UrineTestInforConfiguration : IEntityTypeConfiguration<UrineTestInfor>
    {
        public void Configure(EntityTypeBuilder<UrineTestInfor> builder)
        {
            builder.ToTable("UrineTestInfors");
            //primary key
            builder.HasKey(x => x.urineTestId);
            //attribute
            builder.Property(x => x.mediclatestype).IsRequired().HasMaxLength(100);
            builder.Property(x => x.color).IsRequired().HasMaxLength(100);
            builder.Property(x => x.calrity).IsRequired().HasMaxLength(100);
            builder.Property(x => x.odor).IsRequired().HasMaxLength(100);
            builder.Property(x => x.specificgravity).IsRequired().HasMaxLength(100);
            builder.Property(x => x.glucose).IsRequired();
            builder.Property(x => x.description).HasDefaultValue("").HasMaxLength(500);
            builder.Property(x => x.lastModified).IsRequired().HasDefaultValue(new DateTime());

            //foreign key
            builder.HasOne(x => x.patient).WithMany(x => x.urineTestInfors).HasForeignKey(x => x.patientId);
        }
    }
}
