using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.ToTable("Medicines");

            builder.HasKey(x => x.medicineId);
            builder.Property(x => x.medicineName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.price).IsRequired();
            builder.Property(x => x.company).IsRequired().HasMaxLength(100);
            builder.Property(x => x.lastModified).IsRequired().HasDefaultValue(new DateTime());
            builder.Property(x => x.description).HasMaxLength(500);
        }
    }
}
