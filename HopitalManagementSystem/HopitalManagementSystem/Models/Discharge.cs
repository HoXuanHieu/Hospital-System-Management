using HospitalManagementSystem.SoftDelete;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Discharge : IEFSoftDelete
    {
        [Key]
        public int dischargeId { get; set; }
        [Required]
        public string joinDate { get; set; }
        [Required]
        public string dischargeDate { get; set; }
        public DateTime lastModified { get; set; }


        [Required]
        public int patientId { get; set; }
        public Patient patient { get; set; }
        public bool isDelete { get; set; }

    }
}
