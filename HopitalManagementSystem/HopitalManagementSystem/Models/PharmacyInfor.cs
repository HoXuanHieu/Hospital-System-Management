using HospitalManagementSystem.SoftDelete;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class PharmacyInfor : IEFSoftDelete
    {

        public int pharmacyInforId { get; set; }

        public string department { get; set; }
        public string status { get; set; }   
        public int quantity { get; set; }
        public string description { get; set; }
        public bool isDelete { get; set; }
        public DateTime lastModified { get; set; }


        public Medicine medicine { get; set; }
        public int medicineId { get; set; }
        public int patientId { get; set; }
        public Patient patient { get; set; }    
    }
}
