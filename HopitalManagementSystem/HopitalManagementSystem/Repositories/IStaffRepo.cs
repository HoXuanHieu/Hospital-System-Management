using System.Collections.Generic;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Repositories
{
    public interface IStaffRepo
    {
        //getAll, getById, create, update, delete, savechange
        IEnumerable<Staff> getAll();
        IEnumerable<Staff> getAllBySql();
        IEnumerable<Staff> getAllSurgeryDoctor();
        void CreateListDoctor(List<Staff> doctors);
        Staff getDoctorByUserName(string userName);
        Staff getDoctorByPhoneNumber(string phoneNumber);
        Staff getDoctorByEmail(string email);

        Staff getById(int id);
        void createStaff(Staff staff);
        void updateStaff(Staff staff);
        void deleteStaff(Staff staff);
        IEnumerable<Staff> getSortListDoctor(string searchText, string sortBy, string status, int pageNumber, int pageSize);
        IEnumerable<StaffDapperDTO> getSortListDoctorByDapper(string searchText, string sortBy, string status, int pageNumber, int pageSize);
        int getTotalPage(string searchText, int pageSize);
        bool saveChange();
    }
}
