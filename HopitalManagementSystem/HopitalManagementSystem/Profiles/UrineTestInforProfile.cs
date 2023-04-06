using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Profiles
{
    public class UrineTestInforProfile : Profile
    {
        public UrineTestInforProfile() {
            CreateMap<UrineTestInforUpdateDTO, UrineTestInfor>();
            CreateMap<UrineTestInforCreateDTO, UrineTestInfor>();
            CreateMap<UrineTestInfor, UrineTestInforUpdateDTO>();
            CreateMap<UrineTestInfor, UrineTestInforShowDTO>();
        }
    }
}
