using System;

namespace HospitalManagementSystem.DTO
{
    public class OutPatientShowbyDepartmentDTO
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
        public string patientName { get; set; }

    }
}
