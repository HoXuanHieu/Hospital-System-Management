using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DTO
{
    public class PharmacyInforCreateDTO
    {

        public string department { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public string description { get; set; }

        public int medicineId { get; set; }
        public int patientId { get; set; }
    }
}
