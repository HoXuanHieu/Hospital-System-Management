using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class OutPatientShowDTO
    {
        [Key]
        public int outPatientId { get; set; }
        [Required]
        public string familyPhone { get; set; }
        [Required]
        public string onDate { get; set; }
        [Required]
        public string department { get; set; }
        //foreign key
        [Required]
        public int patientId { get; set; }
        [Required]
        public int staffId { get; set; }
        public DateTime lastModified { get; set; }


    }
}
