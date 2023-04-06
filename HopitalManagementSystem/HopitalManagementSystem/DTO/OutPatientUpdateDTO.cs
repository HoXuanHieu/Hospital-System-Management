using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class OutPatientUpdateDTO
    {
        [Key]
        public int outPatientId { get; set; }
        [Required]
        public string familyPhone { get; set; }
        [Required]
        public string onDate { get; set; }
        [Required]
        public string department { get; set; }

    }
}
