using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class DisChargeCreateDTO
    {
        [Required]
        public string joinDate { get; set; }
        [Required]
        public string dischargeDate { get; set; }
        [Required]
        public int patientId { get; set; }
    }
}
