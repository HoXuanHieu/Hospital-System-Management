using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Repositories
{
    public interface IInPatientRepo
    {
        //getAll, getById, create, update, delete, savechange
        IEnumerable<InPatient> getAll();
        InPatient getById(int id);
        void createInPatient(InPatient inPatient);
        void updateInPatient(InPatient inPatient);
        void deleteInPatient(InPatient inPatient);
        IEnumerable<InPatient> getInPatientListById(int id);
        IEnumerable<InPatientShowWithDoctorNameDTO> getInPatientListByIdWithDoctorName(int id);
        IEnumerable<InPatientShowbyDepartment> getInPatientListByDepartment(string department);

        bool saveChange();
    }
}
