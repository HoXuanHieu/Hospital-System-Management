using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HospitalManagementSystem.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        //public int doctorId { get; set; }
        //public string doctorName { get; set; }
        //public string userName { get; set; }
        //public string password { get; set; }
        //public int age { get; set; }
        //public string gender { get; set; }
        //public string department { get; set; }
        //public string specialization { get; set; }
        //public string phoneNumber { get; set; }
        //public string address { get; set; }
        //public string email { get; set; }
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staffs");
            //primary key
            builder.HasKey(x => x.staffId);
            //attribute
            builder.Property(x => x.staffName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.userName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.age).IsRequired().HasMaxLength(10);
            builder.Property(x => x.gender).IsRequired().HasMaxLength(10);
            builder.Property(x => x.department).IsRequired().HasMaxLength(100);
            builder.Property(x => x.phoneNumber).IsRequired().HasMaxLength(12);
            builder.Property(x => x.address).HasMaxLength(500);
            builder.Property(x => x.email).HasDefaultValue("").HasMaxLength(100);
            builder.Property(x => x.lastAccess).IsRequired().HasDefaultValue(new DateTime());
            builder.Property(x => x.role).IsRequired();
        }
    }
}
