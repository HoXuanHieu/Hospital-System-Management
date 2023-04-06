using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class DischargeConfiguration : IEntityTypeConfiguration<Discharge>
    {
        public void Configure(EntityTypeBuilder<Discharge> builder)
        {
            builder.ToTable("Discharges");
            //primary key
            builder.HasKey(x => x.dischargeId);
            //
            builder.Property(x => x.joinDate).IsRequired();
            builder.Property(x => x.dischargeDate).IsRequired();
            builder.Property(x => x.lastModified).IsRequired().HasDefaultValue(new DateTime());


            builder.HasOne(x => x.patient).WithMany(x => x.discharges).HasForeignKey(x => x.patientId);
        }
    }
}
