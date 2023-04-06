using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class InPatientShowDTO
    {
        [Key]
        public int inPatientId { get; set; }
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
        [Required]
        public int staffId { get; set; }
        [Required]
        public int patientId { get; set; }
        public DateTime lastModified { get; set; }

    }
}
