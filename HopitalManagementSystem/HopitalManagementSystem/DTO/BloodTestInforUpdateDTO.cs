using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DTO
{
    public class BloodTestInforUpdateDTO
    {
        [Required]
        public string Mediclatestype { get; set; }
        [Required]
        public string bloodGroup { get; set; }
        [Required]
        public float haemoglobin { get; set; }
        [Required]
        public float bloodsugar { get; set; }
        [Required]
        public float sacid { get; set; }
        public string description { get; set; }
        //foreign key
    }
}
