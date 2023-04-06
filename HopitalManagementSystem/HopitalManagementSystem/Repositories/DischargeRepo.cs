using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem.Repositories
{
    public class DischargeRepo : IDishargeRepo
    {
        private readonly HospitalManagermentContext _context;

        public DischargeRepo(HospitalManagermentContext context)
        {
            _context = context;
        }
        public void createDischarge(Discharge discharge)
        {
            if (discharge == null)
            {
                throw new ArgumentNullException(nameof(discharge));
            }
            discharge.isDelete = false;
            _context.Add(discharge);
        }

        public void deleteDischarge(Discharge discharge)
        {
            if (discharge == null)
            {
                throw new ArgumentNullException();
            }
            discharge.isDelete = true;
            _context.Update(discharge);
        }

        public IEnumerable<Discharge> getAll()
        {
            var listDischarges = _context.discharges.Where(x => x.isDelete == false).OrderByDescending(x => x.lastModified).ToList();
            return listDischarges;
        }

        public Discharge getById(int id)
        {
            return _context.discharges.FirstOrDefault(x => x.dischargeId == id && x.isDelete == false);
        }

        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void updateDischarge(Discharge discharge)
        {
            if (discharge == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(discharge);
        }
    }
}
