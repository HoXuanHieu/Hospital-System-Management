using HospitalManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class OutPatientShowWithDoctorName
    {
        public int outPatientId { get; set; }
        public string familyPhone { get; set; }
        public string onDate { get; set; }
        public string department { get; set; }
        public bool isDelete { get; set; }
        public DateTime lastModified { get; set; }
        public int patientId { get; set; }
        public int staffId { get; set; }
        public string staffName { get; set; }
    }
}
