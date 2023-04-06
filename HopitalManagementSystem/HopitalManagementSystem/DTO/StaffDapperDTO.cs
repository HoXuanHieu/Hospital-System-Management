using System.ComponentModel.DataAnnotations;
using System;

namespace HospitalManagementSystem.DTO
{
    public class StaffDapperDTO
    {
        public int RowNumber { get; set; }
        public int staffId { get; set; }       
        public string staffName { get; set; }       
        public string userName { get; set; }
        public string password { get; set; }        
        public int age { get; set; }      
        public string gender { get; set; }       
        public string department { get; set; }
        public string specialization { get; set; }
        public string phoneNumber { get; set; }       
        public string address { get; set; }
        public string email { get; set; }
        public DateTime lastAccess { get; set; }
        public string role { get; set; }
        public bool isDelete { get; set; }
    }
}
