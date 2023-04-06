using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Profiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile() {
            CreateMap<StaffUpdateDTO, Staff>();
            CreateMap<StaffCreateDTO, Staff>();
            CreateMap<Staff, StaffUpdateDTO>();
            CreateMap<Staff, StaffShowDTO>();
            CreateMap<StaffDapperDTO, StaffShowDTO>();
            CreateMap<StaffShowDTO, StaffDapperDTO>();

        }
    }
}
