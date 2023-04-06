using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DTO
{
    public class SurgeryInforUpdateDTO
    {
        public string status { get; set; }
        [Required]
        public string result { get; set; }
        public string description { get; set; }

    }
}
