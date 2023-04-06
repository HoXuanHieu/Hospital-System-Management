using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Models
{
    public class Medicine
    {
        public int medicineId { get; set; }  

        public string medicineName { get; set; }
        public float price { get; set; }
        public string company { get; set; }
        public string description { get; set; }
        public bool isDelete { get; set; }
        public DateTime lastModified { get; set; }


        public List<PharmacyInfor> pharmacyInfors { get; set; }
    }
}
