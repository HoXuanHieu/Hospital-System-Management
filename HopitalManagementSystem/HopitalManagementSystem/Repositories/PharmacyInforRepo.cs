using Dapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HospitalManagementSystem.Repositories
{
    public class PharmacyInforRepo : IPharmacyInforRepo
    {
        private readonly HospitalManagermentContext _context;
        private readonly IConfiguration _configuration;
        public string ConnetionString { get; }

        public PharmacyInforRepo(HospitalManagermentContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            ConnetionString = configuration.GetConnectionString("DbConnection");
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnetionString);
            }
        }
        public void createPharmacyInfor(PharmacyInfor pharmacyInfor)
        {
            if (pharmacyInfor == null)
            {
                throw new ArgumentNullException(nameof(pharmacyInfor));
            }
            pharmacyInfor.isDelete = false;
            _context.Add(pharmacyInfor);
        }

        public void deletePharmacyInfor(PharmacyInfor pharmacyInfor)
        {
            if (pharmacyInfor == null)
            {
                throw new ArgumentNullException();
            }
            pharmacyInfor.isDelete = true;
            _context.Update(pharmacyInfor);
        }

        public IEnumerable<PharmacyInfor> getAll()
        {
            var listPharmacyInfor = _context.pharmacyInfors.Where(x => x.isDelete == false).OrderByDescending(x => x.lastModified).ToList();
            return listPharmacyInfor;
        }

        public IEnumerable<PharmacyShowByDepartmentDTO> getAllByDepartment(string department)
        {
            var listPharmacy = new List<PharmacyShowByDepartmentDTO>();
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    listPharmacy = connection.Query<PharmacyShowByDepartmentDTO>("getPharmacyInforBydepartment", new { department = department }, commandType: CommandType.StoredProcedure).ToList();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
            return listPharmacy;
        }

        public PharmacyInfor getById(int id)
        {
            return _context.pharmacyInfors.FirstOrDefault(x => x.pharmacyInforId == id && x.isDelete == false);
        }

        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void updatePharmacyInfor(PharmacyInfor pharmacyInfor)
        {
            if (pharmacyInfor == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(pharmacyInfor);
        }

        public IEnumerable<PharmacyShowByDepartmentDTO> getPharmacyByPatientId(int patientId)
        {
            var listPharmacy = new List<PharmacyShowByDepartmentDTO>();
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    listPharmacy = connection.Query<PharmacyShowByDepartmentDTO>("getPharmacyByPatientId", new { patientId = patientId }, commandType: CommandType.StoredProcedure).ToList();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
            return listPharmacy;
        }
    }
}
