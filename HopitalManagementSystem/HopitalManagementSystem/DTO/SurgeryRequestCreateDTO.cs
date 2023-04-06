using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class SurgeryRequestCreateDTO
    {
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
    }
}
