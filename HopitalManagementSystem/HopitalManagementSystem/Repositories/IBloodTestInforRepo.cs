using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Repositories
{
    public interface IBloodTestInforRepo
    {
        //getAll, getById, create, update, delete, savechange
        IEnumerable<BloodTestInfor> getAll();
        IEnumerable<BloodTestInfoShowWithPatientNameDTO> getAllWithPatientName();
        BloodTestInfor getById(int id);
        void createBloodTestInfor(BloodTestInfor bloodTestInfor);
        void updateBloodTestInfor(BloodTestInfor bloodTestInfor);
        void deleteBloodTestInfor(BloodTestInfor bloodTestInfor);
        bool saveChange();
    }
}
