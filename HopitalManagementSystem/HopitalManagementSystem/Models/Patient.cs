using HospitalManagementSystem.SoftDelete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Patient : IEFSoftDelete
    {
        [Key]
        public int patientId { get; set; }
        [Required]
        public string patientName { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string address { get; set; }
        public string occupation { get; set; }
        public bool isDelete { get; set; }
        public DateTime lastModified { get; set; }


        //set up foreign key
        public List<OutPatient> outPatients { get; set; }
        public List<InPatient> inPatients { get; set; }
        public List<BloodTestInfor> bloodTestInfors { get; set; }   
        public List<UrineTestInfor> urineTestInfors { get;set; }
        //public List<SurgeryInfor> surgeryInfors { get; set; }   
        public List<SurgeryRequest> surgeryRequests { get; set; }
        public List<Discharge> discharges { get; set; }
        public List<PharmacyInfor> pharmacyInfors { get; set; }
    }
}
