using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DTO
{
    public class PatientShowDTO
    {
        [Key]
        public int patientId { get; set; }
        [Required]
        public string patientName { get; set; }
        [Required]  
        public int age { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string address { get; set; }
        public string occupation { get; set; }
        public DateTime lastModified { get; set; }

    }
}
