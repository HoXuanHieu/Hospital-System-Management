using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class SurgeryRequestConfiguration : IEntityTypeConfiguration<SurgeryRequest>
    {
        public void Configure(EntityTypeBuilder<SurgeryRequest> builder)
        {
            builder.ToTable("SurgeryRequest");
            //primary key
            builder.HasKey(x => x.surgeryRequestId);
            //attribute
            builder.Property(x => x.surgeryTpye).IsRequired().HasMaxLength(100);
            builder.Property(x => x.surgeryDate).IsRequired().HasMaxLength(100);
            builder.Property(x => x.status).IsRequired().HasMaxLength(100);
            builder.Property(x => x.description).HasMaxLength(500);
            builder.Property(x => x.lastModified).IsRequired().HasDefaultValue(new DateTime());

            //foriegn key
            builder.HasOne(x => x.patient).WithMany(x => x.surgeryRequests).HasForeignKey(x => x.patientId);
            builder.HasOne(x => x.staff).WithMany(x => x.surgeryRequests).HasForeignKey(x => x.staffId);
        }
    }
}
