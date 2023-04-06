using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Repositories
{
    public interface IDishargeRepo
    {
        //getAll, getById, create, update, delete, savechange
        IEnumerable<Discharge> getAll();
        Discharge getById(int id);
        void createDischarge(Discharge discharge);
        void updateDischarge(Discharge discharge);
        void deleteDischarge(Discharge discharge);
        bool saveChange();
    }
}
