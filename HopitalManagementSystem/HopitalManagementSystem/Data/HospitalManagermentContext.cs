using HospitalManagementSystem.Configurations;
using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Data
{
    public class HospitalManagermentContext : DbContext
    {
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<InPatient> inPatients { get; set; }
        public DbSet<OutPatient> outPatients { get; set; }
        public DbSet<BloodTestInfor> bloodTestInfors { get; set; }
        public DbSet<UrineTestInfor> urineTestInfors { get; set; }
        public DbSet<SurgeryInfor> surgeryInfors { get; set; }
        public DbSet<SurgeryRequest> surgeryRequests { get; set; }
        public DbSet<Discharge> discharges { get; set; }
        public DbSet<PharmacyInfor> pharmacyInfors { get; set; }
        public DbSet<Medicine> medicines { get; set; }
        public HospitalManagermentContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = string.Format("Data Source=CVPHIEUHX1;Initial Catalog=HopitalManagerment;User ID=sa;Password=hieuhohieuho123;TrustServerCertificate=true;");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BloodTestInforConfiguration());
            modelBuilder.ApplyConfiguration(new DischargeConfiguration());
            modelBuilder.ApplyConfiguration(new InPatientConfiguration());
            modelBuilder.ApplyConfiguration(new OutPatientConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new PharmacyInforConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new SurgeryInforConfiguration());
            modelBuilder.ApplyConfiguration(new SurgeryRequestConfiguration());
            modelBuilder.ApplyConfiguration(new UrineTestInforConfiguration());
            modelBuilder.ApplyConfiguration(new MedicineConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
