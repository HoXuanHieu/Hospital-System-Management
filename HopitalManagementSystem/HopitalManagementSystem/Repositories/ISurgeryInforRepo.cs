using System.Collections.Generic;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Repositories
{
    public interface ISurgeryInforRepo
    {
        //getAll, getById, create, update, delete, savechange
        IEnumerable<SurgeryInfor> getAll();
        SurgeryInfor getById(int id);
        void createSurgeryInfor(SurgeryInfor surgeryInfor);
        void updateSurgeryInfor(SurgeryInfor surgeryInfor);
        void deleteSurgeryInfor(SurgeryInfor surgeryInfor);
        bool saveChange();
    }
}
