using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class PharmacyInforConfiguration : IEntityTypeConfiguration<PharmacyInfor>
    {
        public void Configure(EntityTypeBuilder<PharmacyInfor> builder)
        {
            builder.ToTable("PharmaceInfors");
            //primary key
            builder.HasKey(x => x.pharmacyInforId);
            //attribute
            builder.Property(x => x.department).IsRequired().HasMaxLength(100);
            builder.Property(x => x.status).IsRequired().HasMaxLength(20);
            builder.Property(x => x.quantity).IsRequired();
            builder.Property(x => x.description).HasDefaultValue("").HasMaxLength(500);
            builder.Property(x => x.lastModified).IsRequired().HasDefaultValue(new DateTime());

            //foreign key
            builder.HasOne(x => x.patient).WithMany(x => x.pharmacyInfors).HasForeignKey(x => x.patientId);
            builder.HasOne(x => x.medicine).WithMany(x => x.pharmacyInfors).HasForeignKey(x => x.medicineId);
        }
    }
}
