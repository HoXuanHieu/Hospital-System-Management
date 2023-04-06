using HospitalManagementSystem.SoftDelete;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class UrineTestInfor : IEFSoftDelete
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
        public bool isDelete { get; set; }
        public DateTime lastModified { get; set; }
        //foreign key
        [Required]
        public int patientId { get; set; }
        public Patient patient { get; set; }

    }
}
