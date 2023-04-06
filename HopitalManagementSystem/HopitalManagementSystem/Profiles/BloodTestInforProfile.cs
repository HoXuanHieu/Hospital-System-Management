using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Profiles
{
    public class BloodTestInforProfile : Profile
    {
        public BloodTestInforProfile()
        {
            CreateMap<BloodTestInfor, BloodTestInforShowDTO>();
            CreateMap<BloodTestInfor, BloodTestInforUpdateDTO>();
            CreateMap<BloodTestInforUpdateDTO, BloodTestInfor>();
            CreateMap<BloodTestinforCreateDTO, BloodTestInfor>();
        }
    }
}
