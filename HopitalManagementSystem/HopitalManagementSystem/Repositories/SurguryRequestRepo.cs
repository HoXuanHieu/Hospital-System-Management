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
    public class SurguryRequestRepo : ISurgeryRequestRepo
    {
        private readonly HospitalManagermentContext _context;
        private readonly IConfiguration _configuration;
        public string ConnetionString { get; }

        public SurguryRequestRepo(HospitalManagermentContext context, IConfiguration configuration)
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
        public void createSurgeryRequest(SurgeryRequest surgeryRequest)
        {
            if (surgeryRequest == null)
            {
                throw new ArgumentNullException(nameof(surgeryRequest));
            }
            surgeryRequest.isDelete = false;
            _context.Add(surgeryRequest);
        }

        public void deleteSurgeryRequest(SurgeryRequest surgeryRequest)
        {
            if (surgeryRequest == null)
            {
                throw new ArgumentNullException();
            }
            surgeryRequest.isDelete = true;
            _context.Update(surgeryRequest);
        }

        public IEnumerable<SurgeryRequest> getAll()
        {
            var listSurgeryRequest = _context.surgeryRequests.Where(x => x.isDelete == false).OrderByDescending(x => x.lastModified).ToList();
            return listSurgeryRequest;
        }

        public IEnumerable<SurgeryRequestWithNameDTO> getAllWithName()
        {

            List<SurgeryRequestWithNameDTO> result = new List<SurgeryRequestWithNameDTO>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    result = dbConnection.Query<SurgeryRequestWithNameDTO>("getSurgeryRequestWithName", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return result;
            }
        }

        public IEnumerable<SurgeryRequestWithNameDTO> getSurgeryRequestbyStaffId(int id)
        {

            List<SurgeryRequestWithNameDTO> result = new List<SurgeryRequestWithNameDTO>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    result = dbConnection.Query<SurgeryRequestWithNameDTO>("getSurgeryRequestbyStaffId", new { staffId = id }, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return result;
            }
        }

        public SurgeryRequest getById(int id)
        {
            return _context.surgeryRequests.FirstOrDefault(x => x.surgeryRequestId == id && x.isDelete == false);

        }

        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void updateSurgeryRequest(SurgeryRequest surgeryRequest)
        {
            if (surgeryRequest == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(surgeryRequest);
        }
    }
}
