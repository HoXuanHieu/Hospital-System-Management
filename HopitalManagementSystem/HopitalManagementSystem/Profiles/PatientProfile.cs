using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile() {
            CreateMap<Patient, PatientShowDTO>();
            CreateMap<Patient, PatientUpdateDTO>();
            CreateMap<PatientUpdateDTO, Patient>();
            CreateMap<PatientCreateDTO, Patient>();

        }
    }
}
