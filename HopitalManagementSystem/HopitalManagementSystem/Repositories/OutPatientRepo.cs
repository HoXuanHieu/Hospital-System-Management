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
    public class OutPatientRepo : IOutPatientRepo
    {
        private readonly HospitalManagermentContext _context;
        private readonly IConfiguration _configuration;
        public string ConnetionString { get; }

        public OutPatientRepo(HospitalManagermentContext context, IConfiguration configuration)
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
        public void createOutPatient(OutPatient outPatient)
        {
            if (outPatient == null)
            {
                throw new ArgumentNullException(nameof(outPatient));
            }
            outPatient.isDelete = false;
            _context.Add(outPatient);
        }

        public void deleteOutPatient(OutPatient outPatient)
        {
            if (outPatient == null)
            {
                throw new ArgumentNullException();
            }
            outPatient.isDelete = true;
            _context.Update(outPatient);
        }

        public IEnumerable<OutPatient> getAll()
        {
            var listoutPatient = _context.outPatients.Where(x => x.isDelete == false).ToList();
            return listoutPatient;
        }

        public OutPatient getById(int id)
        {
            return _context.outPatients.FirstOrDefault(x => x.outPatientId == id && x.isDelete == false);

        }

        public IEnumerable<OutPatient> getOutPatientListById(int id)
        {
            var listOutPatient = _context.outPatients.Where(x => x.isDelete == false && x.patientId == id).OrderByDescending(x => x.lastModified).ToList();
            return listOutPatient;
        }

        public IEnumerable<OutPatientShowWithDoctorName> getOutPatientListByIdWithDoctorName(int id)
        {
            var listOutPatient = new List<OutPatientShowWithDoctorName>();
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    listOutPatient = connection.Query<OutPatientShowWithDoctorName>("getListOutPatientWithDoctorName", new { patientId = id }, commandType: CommandType.StoredProcedure).ToList();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
            return listOutPatient;
        }

        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void updateOutPatient(OutPatient outPatient)
        {
            if (outPatient == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(outPatient);
        }

        public IEnumerable<OutPatientShowbyDepartmentDTO> getOutPatientListByDepartment(string department)
        {
            var listOutPatient = new List<OutPatientShowbyDepartmentDTO>();
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    listOutPatient = connection.Query<OutPatientShowbyDepartmentDTO>("getOutpatientByDepartment", new { department = department }, commandType: CommandType.StoredProcedure).ToList();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
            return listOutPatient;
        }
    }
}
