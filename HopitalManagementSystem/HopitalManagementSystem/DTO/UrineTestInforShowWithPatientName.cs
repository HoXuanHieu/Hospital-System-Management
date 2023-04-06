using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class UrineTestInforShowWithPatientName
    {
        public int urineTestId { get; set; }
        public string mediclatestype { get; set; }
        public string color { get; set; }
        public string calrity { get; set; }
        public string odor { get; set; }
        public string specificgravity { get; set; }
        public float glucose { get; set; }
        public string description { get; set; }
        public int patientId { get; set; }
        public DateTime lastModified { get; set; }
        public string patientName { get; set; }
    }
}
