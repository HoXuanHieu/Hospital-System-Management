using HospitalManagementSystem.SoftDelete;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class SurgeryInfor : IEFSoftDelete
    {
        [Key]
        public int surgeryInforId { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public string result { get; set; }
        public string description { get; set; }
        public bool isDelete { get; set; }
        public DateTime lastModified { get; set; }


        //foreign key
        //
        //1-n 
        //[Required]
        //public int patientId { get; set; }
        //public Patient patient { get; set; }
        //1-1
        [Required]
        public int surgeryRequestId { get; set; }
        public SurgeryRequest surgeryRequest { get; set; }

    }
}
