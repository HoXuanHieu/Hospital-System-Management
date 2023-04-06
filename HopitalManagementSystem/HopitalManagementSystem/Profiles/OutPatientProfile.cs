using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Profiles
{
    public class OutPatientProfile : Profile
    {
        public OutPatientProfile() {
            CreateMap<OutPatient, OutPatientShowDTO>();
            CreateMap<OutPatient, OutPatientUpdateDTO>();
            CreateMap<OutPatientCreateDTO, OutPatient > ();
            CreateMap<OutPatientUpdateDTO, OutPatient > ();

        }
    }
}
