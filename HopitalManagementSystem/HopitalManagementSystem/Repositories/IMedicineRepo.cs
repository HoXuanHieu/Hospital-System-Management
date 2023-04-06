using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Repositories
{
    public interface IMedicineRepo
    {
        IEnumerable<Medicine> getAll();
        Medicine getById(int id);
        Medicine getByNam(string name);
        void createMedicine(Medicine medicine);
        void updateMedicine(Medicine medicine);
        void deleteMedicine(Medicine medicine);
        void CreateListMedicine(List<Medicine> medicines);
        bool saveChange();
    }
}
