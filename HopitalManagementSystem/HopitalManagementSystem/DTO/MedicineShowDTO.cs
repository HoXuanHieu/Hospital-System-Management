using System;

namespace HospitalManagementSystem.DTO
{
    public class MedicineShowDTO
    {
        public int medicineId { get; set; }

        public string medicineName { get; set; }
        public float price { get; set; }
        public string company { get; set; }
        public string description { get; set; }
        public DateTime lastModified { get; set; }

    }
}
