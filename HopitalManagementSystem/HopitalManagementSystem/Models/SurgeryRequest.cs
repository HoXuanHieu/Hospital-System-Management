using HospitalManagementSystem.SoftDelete;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class SurgeryRequest : IEFSoftDelete
    {
        [Key]
        public int surgeryRequestId { get; set; }
        [Required]
        public string surgeryTpye { get; set; }
        [Required]
        public string surgeryDate { get; set; }
        [Required]
        public string status { get; set; }
        public string description { get; set; }
        public bool isDelete { get; set; }
        public DateTime lastModified { get; set; }

        //setup foreign key
        public SurgeryInfor surgeryInfor { get; set; }

        //foreign key
        [Required]
        public int patientId { get; set; }
        public Patient patient { get; set; }
        [Required]
        public int staffId { get; set; }
        public Staff staff { get; set; }
    }
}
