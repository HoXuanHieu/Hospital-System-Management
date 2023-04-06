using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Profiles
{
    public class MedicineProfile: Profile
    {
        public MedicineProfile() {
            CreateMap<MedicineCreateDTO, Medicine>();
            CreateMap<Medicine, MedicineShowDTO>();
        }

    }
}
