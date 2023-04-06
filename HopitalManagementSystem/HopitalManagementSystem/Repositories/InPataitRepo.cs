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
    public class InPataitRepo : IInPatientRepo
    {
        private readonly HospitalManagermentContext _context;
        private readonly IConfiguration _configuration;
        public string ConnetionString { get; }


        public InPataitRepo(HospitalManagermentContext context, IConfiguration configuration)
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
        public void createInPatient(InPatient inPatient)
        {
            if (inPatient == null)
            {
                throw new ArgumentNullException(nameof(inPatient));
            }
            inPatient.isDelete = false;
            _context.Add(inPatient);
        }

        public void deleteInPatient(InPatient inPatient)
        {
            if (inPatient == null)
            {
                throw new ArgumentNullException();
            }
            inPatient.isDelete = true;
            _context.Update(inPatient);
        }

        public IEnumerable<InPatient> getAll()
        {
            var listInPatient = _context.inPatients.Where(x => x.isDelete == false).ToList();
            return listInPatient;
        }


        public InPatient getById(int id)
        {
            return _context.inPatients.FirstOrDefault(x => x.inPatientId == id && x.isDelete == false);

        }

        public IEnumerable<InPatient> getInPatientListById(int id)
        {
            var listInPatient = _context.inPatients.Where(x => x.isDelete == false && x.patientId == id).OrderByDescending(x => x.lastModified).ToList();
            return listInPatient;
        }
        public IEnumerable<InPatientShowWithDoctorNameDTO> getInPatientListByIdWithDoctorName(int id)
        {
            var listInPatient = new List<InPatientShowWithDoctorNameDTO>();
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    listInPatient = connection.Query<InPatientShowWithDoctorNameDTO>("getListInPatientWithDoctorName", new { patientId = id}, commandType: CommandType.StoredProcedure).ToList();
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
            return listInPatient;
        }

        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void updateInPatient(InPatient inPatient)
        {
            if (inPatient == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(inPatient);
        }

        public IEnumerable<InPatientShowbyDepartment> getInPatientListByDepartment(string department)
        {
            var listInPatient = new List<InPatientShowbyDepartment>();
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    listInPatient = connection.Query<InPatientShowbyDepartment>("getInpatientByDepartment", new { department = department }, commandType: CommandType.StoredProcedure).ToList();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
            return listInPatient;
        }
    }
}
