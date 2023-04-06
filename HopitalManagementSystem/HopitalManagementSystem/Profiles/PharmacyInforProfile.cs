using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Profiles
{
    public class PharmacyInforProfile : Profile
    {
        public PharmacyInforProfile() {
            CreateMap<PharmacyInforCreateDTO, PharmacyInfor>();
            CreateMap<PharmacyInforUpdateDTO, PharmacyInfor>();
            CreateMap<PharmacyInfor, PharmacyInforShowDTO>();
            CreateMap<PharmacyInfor, PharmacyInforUpdateDTO>();

        }
    }
}
