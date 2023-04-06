using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HopitalManagementSystem.Profiles
{
    public class SurgreryInforProfile : Profile
    {
        public SurgreryInforProfile() {
            CreateMap<SurgeryInforCreateDTO, SurgeryInfor>();
            CreateMap<SurgeryInforUpdateDTO, SurgeryInfor>();
            CreateMap<SurgeryInfor, SurgeryInforUpdateDTO>();
            CreateMap<SurgeryInfor, SurgeryInforShowDTO>();


        }
    }
}
