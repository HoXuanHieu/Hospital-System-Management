using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class SurgeryRequestWithNameDTO
    {
        public int surgeryRequestId { get; set; }
        [Required]
        public string surgeryTpye { get; set; }
        [Required]
        public string surgeryDate { get; set; }
        [Required]
        public string status { get; set; }
        public string description { get; set; }
        public bool isDelete { get; set; }
        public DateTime lastModified { get; set; }
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int staffId { get; set; }
        public string staffName { get; set;}
    }
}
