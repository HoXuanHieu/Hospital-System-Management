using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DTO
{
    public class PharmacyInforUpdateDTO
    {
        [Required]
        public string department { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public int quantity { get; set; }
        public int medicineId { get; set; }
        public string description { get; set; }
    }
}
