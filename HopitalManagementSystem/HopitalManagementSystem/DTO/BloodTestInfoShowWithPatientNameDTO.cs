using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class BloodTestInfoShowWithPatientNameDTO
    {
        public int bloodTestId { get; set; }
        public string Mediclatestype { get; set; }
        public string bloodGroup { get; set; }
        public float haemoglobin { get; set; }
        public float bloodsugar { get; set; }
        public float sacid { get; set; }
        public string description { get; set; }
        //foreign key
        public int patientId { get; set; }
        public DateTime lastModified { get; set; }
        public string PatientName { get; set; }
    }
}
