using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DTO
{
    public class SurgeryInforShowDTO
    {
        public int surgeryInforId { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public string result { get; set; }
        public string description { get; set; }
        [Required]
        public int surgeryRequestId { get; set; }
        public DateTime lastModified { get; set; }


    }
}
