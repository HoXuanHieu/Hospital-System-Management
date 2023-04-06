using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Profiles
{
    public class DischargeProfile : Profile
    {
        public DischargeProfile() {
            CreateMap<DischargeUpdateDTO, Discharge>();
            CreateMap<Discharge, DischargeUpdateDTO>();
            CreateMap<Discharge, DischargeShowDTO>();
            CreateMap<DisChargeCreateDTO, Discharge>();
        }
    }
}
