using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class InPatientUpdateDTO
    {
        [Required]
        public string familyPhone { get; set; }
        [Required]
        public string dateIn { get; set; }
        [Required]
        public string dateOut { get; set; }
        [Required]
        public string symptoms { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public int wardNum { get; set; }
        [Required]
        public int bedNum { get; set; }
    }
}
