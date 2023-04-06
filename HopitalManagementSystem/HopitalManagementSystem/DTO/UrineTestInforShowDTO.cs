using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DTO
{
    public class UrineTestInforShowDTO
    {
        [Key]
        public int urineTestId { get; set; }
        [Required]
        public string mediclatestype { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public string calrity { get; set; }
        [Required]
        public string odor { get; set; }
        [Required]
        public string specificgravity { get; set; }
        [Required]
        public float glucose { get; set; }
        public string description { get; set; }
        //foreign key
        [Required]
        public int patientId { get; set; }
        public DateTime lastModified { get; set; }

    }
}
