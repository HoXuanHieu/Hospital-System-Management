using System.Collections.Generic;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Repositories
{
    public interface IUrineTestInforRepo
    {
        //getAll, getById, create, update, delete, savechange
        IEnumerable<UrineTestInfor> getAll();
        IEnumerable<UrineTestInforShowWithPatientName> getAllWithPatientName();
        UrineTestInfor getById(int id);
        void createUrineTestInfor(UrineTestInfor urineTestInfor);
        void updateUrineTestInfor(UrineTestInfor urineTestInfor);
        void deleteUrineTestInfor(UrineTestInfor urineTestInfor);
        bool saveChange();
    }
}
