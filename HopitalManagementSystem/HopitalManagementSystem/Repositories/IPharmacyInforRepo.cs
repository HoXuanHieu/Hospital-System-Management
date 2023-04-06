using System.Collections.Generic;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Repositories
{
    public interface IPharmacyInforRepo
    {
                //getAll, getById, create, update, delete, savechange
        IEnumerable<PharmacyInfor> getAll();
        IEnumerable<PharmacyShowByDepartmentDTO> getAllByDepartment(string department);
        PharmacyInfor getById(int id);
        void createPharmacyInfor(PharmacyInfor pharmacyInfor);
        void updatePharmacyInfor(PharmacyInfor pharmacyInfor);
        void deletePharmacyInfor(PharmacyInfor pharmacyInfor);
        IEnumerable<PharmacyShowByDepartmentDTO> getPharmacyByPatientId(int patientId);

        bool saveChange();
    }
}
