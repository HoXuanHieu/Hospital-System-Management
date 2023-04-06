using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DTO
{
    public class PharmacyInforShowDTO
    {
        [Key]
        public int pharmacyInforId { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public int quantity { get; set; }
        public string description { get; set; }
        [Required]
        public int patientId { get; set; }
        public int medicineId { get; set; }
        public DateTime lastModified { get; set; }


    }
}
