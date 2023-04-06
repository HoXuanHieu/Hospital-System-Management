using HospitalManagementSystem.SoftDelete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Staff : IEFSoftDelete
    {
        [Key]
        public int staffId { get; set; }
        [Required]
        public string staffName { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string department { get; set; }
        public string specialization { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string address { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public DateTime lastAccess { get; set; }
        [Required]
        public string role { get; set; }
        public bool isDelete { get; set; }


        //set up foreign key
        public List<OutPatient> outPatients { get; set; }
        public List<InPatient> inPatients { get; set; }
        public List<SurgeryRequest> surgeryRequests { get; set; }
    }
}
