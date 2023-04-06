using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class DischargeUpdateDTO
    {
        [Required]
        public string joinDate { get; set; }
        [Required]
        public string dischargeDate { get; set; }
        
    }
}
