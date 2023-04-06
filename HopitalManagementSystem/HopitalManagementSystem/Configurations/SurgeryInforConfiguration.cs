using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class SurgeryInforConfiguration : IEntityTypeConfiguration<SurgeryInfor>
    {
        public void Configure(EntityTypeBuilder<SurgeryInfor> builder)
        {
            builder.ToTable("SurgeryInfors");
            //primary key
            builder.HasKey(x => x.surgeryInforId);
            //attribute
            builder.Property(x => x.status).IsRequired().HasMaxLength(100);
            builder.Property(x => x.result).IsRequired().HasMaxLength(100);
            builder.Property(x => x.description).HasDefaultValue("").HasMaxLength(500);
            builder.Property(x => x.lastModified).IsRequired().HasDefaultValue(new DateTime());

            //foreign key
            //builder.HasOne(x => x.patient).WithMany(x => x.surgeryInfors).HasForeignKey(x => x.surgeryInforId); 
            builder.HasOne(x => x.surgeryRequest).WithOne(x => x.surgeryInfor).HasForeignKey<SurgeryInfor>(x => x.surgeryRequestId);
        }
    }
}
