using HospitalManagementSystem.SoftDelete;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class InPatient : IEFSoftDelete
    {
        [Key]
        public int inPatientId { get; set; }
        [Required]
        public string familyPhone { get; set; }
        [Required]
        public string dateIn { get; set; }
        [Required]
        public string dateOut { get; set; }
        [Required]
        public string  symptoms { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public int wardNum { get; set; }
        [Required]
        public int bedNum { get; set; }
        public DateTime lastModified { get; set; }


        //foreign key
        [Required]
        public int patientId { get; set; }
        public Patient patient { get; set; }
        [Required]
        public int staffId { get; set; }
        public Staff staff { get; set; }
        public bool isDelete { get; set; }

    }
}
