using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem.Repositories
{
    public class SurgeryInforRepo : ISurgeryInforRepo
    {
        private readonly HospitalManagermentContext _context;

        public SurgeryInforRepo(HospitalManagermentContext context)
        {
            _context = context;
        }
        public void createSurgeryInfor(SurgeryInfor surgeryInfor)
        {
            if (surgeryInfor == null)
            {
                throw new ArgumentNullException(nameof(surgeryInfor));
            }
            surgeryInfor.isDelete = false;
            _context.Add(surgeryInfor);
        }

        public void deleteSurgeryInfor(SurgeryInfor surgeryInfor)
        {
            if (surgeryInfor == null)
            {
                throw new ArgumentNullException();
            }
            surgeryInfor.isDelete = true;
            _context.Update(surgeryInfor);
        }

        public IEnumerable<SurgeryInfor> getAll()
        {
            var listSurgeryInfors = _context.surgeryInfors.Where(x => x.isDelete == false).OrderByDescending(x => x.lastModified).ToList();
            return listSurgeryInfors;
        }
        
        public SurgeryInfor getById(int id)
        {
            return _context.surgeryInfors.FirstOrDefault(x => x.surgeryInforId == id && x.isDelete == false);

        }

        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void updateSurgeryInfor(SurgeryInfor surgeryInfor)
        {
            if (surgeryInfor == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(surgeryInfor);
        }
    }
}
