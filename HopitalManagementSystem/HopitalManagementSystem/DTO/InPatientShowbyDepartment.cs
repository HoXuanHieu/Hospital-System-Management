using System;

namespace HospitalManagementSystem.DTO
{
    public class InPatientShowbyDepartment
    {
        public int inPatientId { get; set; }
        public string familyPhone { get; set; }
        public string dateIn { get; set; }
        public string dateOut { get; set; }
        public string symptoms { get; set; }
        public string department { get; set; }
        public int wardNum { get; set; }
        public int bedNum { get; set; }
        public DateTime lastModified { get; set; }
        public int patientId { get; set; }
        public int staffId { get; set; }
        public string staffName { get; set; }
        public string patientName { get; set; }
    }
}
