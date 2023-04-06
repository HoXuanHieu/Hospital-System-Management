using System;

namespace HospitalManagementSystem.DTO
{
    public class PharmacyShowByDepartmentDTO
    {
        public int pharmacyInforId { get; set; }

        public string department { get; set; }
        public string status { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public int medicineId { get; set; }
        public int patientId { get; set; }
        public string medicineName { get; set; }
        public string patientName { get; set; }
    }
}
