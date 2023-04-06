using System.Collections.Generic;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Repositories
{
    public interface ISurgeryRequestRepo
    {
        //getAll, getById, create, update, delete, savechange
        IEnumerable<SurgeryRequest> getAll();
        IEnumerable<SurgeryRequestWithNameDTO> getAllWithName();
        IEnumerable<SurgeryRequestWithNameDTO> getSurgeryRequestbyStaffId(int id);
        SurgeryRequest getById(int id);
        void createSurgeryRequest(SurgeryRequest surgeryRequest);
        void updateSurgeryRequest(SurgeryRequest surgeryRequest);
        void deleteSurgeryRequest(SurgeryRequest surgeryRequest);
        bool saveChange();
    }
}
