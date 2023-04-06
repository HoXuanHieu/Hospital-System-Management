﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.DTO
{
    public class StaffUpdateDTO
    {
        [Required]
        public string staffName { get; set; }
        [Required]
        public string userName { get; set; }
        public string password { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string department { get; set; }
        public string specialization { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string address { get; set; }
        [Required]
        public string email { get; set; }
        public string role { get; set; }
    }
}
