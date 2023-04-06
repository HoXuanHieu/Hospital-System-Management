using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Repositories
{
    public interface IOutPatientRepo
    {
         //getAll, getById, create, update, delete, savechange
        IEnumerable<OutPatient> getAll();
        OutPatient getById(int id);
        void createOutPatient(OutPatient outPatient);
        void updateOutPatient(OutPatient outPatient);
        void deleteOutPatient(OutPatient outPatient);
        IEnumerable<OutPatient> getOutPatientListById(int id);
        IEnumerable<OutPatientShowWithDoctorName> getOutPatientListByIdWithDoctorName(int id);
        IEnumerable<OutPatientShowbyDepartmentDTO> getOutPatientListByDepartment(string department);

        bool saveChange();
    }
}
