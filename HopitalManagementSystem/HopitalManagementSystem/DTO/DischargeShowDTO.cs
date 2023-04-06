using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class DischargeShowDTO
    {
        [Key]
        public int dischargeId { get; set; }
        [Required]
        public string joinDate { get; set; }
        [Required]
        public string dischargeDate { get; set; }

        [Required]
        public int patientId { get; set; }
        public DateTime lastModified { get; set; }

    }
}
