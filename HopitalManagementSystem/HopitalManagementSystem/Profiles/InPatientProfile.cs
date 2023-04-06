using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Profiles
{
    public class InPatientProfile : Profile
    {
        public InPatientProfile() {
            CreateMap<InPatient, InPatientUpdateDTO>();
            CreateMap<InPatient, InPatientShowDTO>();
            CreateMap<InPatientUpdateDTO, InPatient>();
            CreateMap<InPatientCreateDTO, InPatient>();

        }
    }
}
