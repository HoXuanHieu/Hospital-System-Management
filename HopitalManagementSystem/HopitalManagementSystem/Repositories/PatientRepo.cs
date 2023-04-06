using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem.Repositories
{
    public class PatientRepo : IPatientRepo
    {
        private readonly HospitalManagermentContext _context;

        public PatientRepo(HospitalManagermentContext context)
        {
            _context = context;
        }
        public void createPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
            patient.isDelete = false;
            _context.Add(patient);
        }

        public void deletePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException();
            }
            patient.isDelete = true;
            _context.Update(patient);
        }

        public IEnumerable<Patient> getAll()
        {
            var listPatient = _context.patients.Where(x => x.isDelete == false).OrderByDescending(x => x.lastModified).ToList();
            return listPatient;
        }

        public Patient getById(int id)
        {
            return _context.patients.FirstOrDefault(x => x.patientId == id && x.isDelete == false);
        }

        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void updatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(patient);
        }
    }
}
