using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.BulkExtensions;
using ExcelDataReader;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Repositories
{
    public class MedicineRepo : IMedicineRepo
    {
        private readonly HospitalManagermentContext _context;

        public MedicineRepo(HospitalManagermentContext context)
        {
            _context = context;
        }

        public void CreateListMedicine(List<Medicine> medicines)
        {
            if (medicines == null)
            {
                throw new ArgumentException();
            }
            foreach (var medicine in medicines)
            {
                // Validate row record, match FE

                // Save value
                InsertOrUpdate(medicine);
            }
        }

        /// <summary>
        /// insert or update record to database
        /// </summary>
        /// <param name="medicine"></param>
        public void InsertOrUpdate(Medicine medicine)
        {
            //var existingMedicine = context.medicines.Find(medicine.medicineName);
            var existingMedicine = _context.medicines.Where(x => x.isDelete == false && x.medicineName == medicine.medicineName).FirstOrDefault();

            if (existingMedicine == null)
            {
                medicine.lastModified = DateTime.Now;
                _context.Add(medicine);
            }
            else
            {
                medicine.medicineId = existingMedicine.medicineId;
                medicine.lastModified = DateTime.Now;
                _context.Entry(existingMedicine).CurrentValues.SetValues(medicine);
            }
            _context.SaveChanges();
        }

        public void createMedicine(Medicine medicine)
        {
            if (medicine == null)
            {
                throw new ArgumentNullException(nameof(medicine));
            }
            medicine.isDelete = false;
            _context.Add(medicine);
        }

        public void deleteMedicine(Medicine medicine)
        {
            if (medicine == null)
            {
                throw new ArgumentNullException();
            }
            medicine.isDelete = true;
            _context.Update(medicine);
        }

        public IEnumerable<Medicine> getAll()
        {
            var lisMedicines = _context.medicines.Where(x => x.isDelete == false).OrderByDescending(x => x.lastModified).ToList();
            return lisMedicines;
        }

        public Medicine getById(int id)
        {
            return _context.medicines.FirstOrDefault(x => x.medicineId == id && x.isDelete == false);

        }


        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void updateMedicine(Medicine medicine)
        {
            if (medicine == null)
            {
                throw new ArgumentNullException();
            }
            medicine.lastModified = DateTime.Now;
            _context.Update(medicine);
        }

        public Medicine getByNam(string name)
        {
            return _context.medicines.FirstOrDefault(x => x.isDelete == false && x.medicineName == name);
        }
    }
}
