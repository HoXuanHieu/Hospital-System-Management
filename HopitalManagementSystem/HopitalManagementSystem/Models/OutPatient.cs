using HospitalManagementSystem.SoftDelete;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class OutPatient : IEFSoftDelete
    {
        [Key]
        public int outPatientId { get; set; }
        [Required]
        public string familyPhone { get; set; }
        [Required]
        public string onDate { get; set; }
        [Required]
        public string department { get; set; }
        public bool isDelete { get; set; }
        public DateTime lastModified { get; set; }


        //foreign key
        [Required]
        public int patientId { get; set; }
        public Patient patient { get; set; }
        [Required]
        public int staffId { get; set; }
        public Staff staff { get; set; }
    }
}
