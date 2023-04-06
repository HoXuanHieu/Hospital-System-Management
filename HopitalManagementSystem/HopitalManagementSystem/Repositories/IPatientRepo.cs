using System.Collections.Generic;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Repositories
{
    public interface IPatientRepo
    {
        //getAll, getById, create, update, delete, savechange
        IEnumerable<Patient> getAll();
        Patient getById(int id);
        void createPatient(Patient patient);
        void updatePatient(Patient patient);
        void deletePatient(Patient patient);
        bool saveChange();
    }
}
