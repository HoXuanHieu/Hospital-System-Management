using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class SurgeryRequestShowDTO
    {
        [Key]
        public int surgeryRequestId { get; set; }
        [Required]
        public string surgeryTpye { get; set; }
        [Required]
        public string surgeryDate { get; set; }
        [Required]
        public string status { get; set; }
        public string description { get; set; }
        [Required]
        public int patientId { get; set; }
        [Required]
        public int staffId { get; set; }
        public DateTime lastModified { get; set; }

    }
}
