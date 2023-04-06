using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Profiles
{
    public class SurgeryRequestProfile : Profile
    {
        public SurgeryRequestProfile() {
            CreateMap<SurgeryRequestUpdateDTO, SurgeryRequest>();
            CreateMap<SurgeryRequestCreateDTO, SurgeryRequest>();
            CreateMap<SurgeryRequest, SurgeryRequestUpdateDTO>();
            CreateMap<SurgeryRequest, SurgeryRequestShowDTO>();

        }
    }
}
