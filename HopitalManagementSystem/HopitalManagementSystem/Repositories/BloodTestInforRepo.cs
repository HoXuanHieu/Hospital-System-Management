using Dapper;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HospitalManagementSystem.Repositories
{
    public class BloodTestInforRepo : IBloodTestInforRepo
    {
        private readonly HospitalManagermentContext _context;
        private readonly IConfiguration _configuration;
        public string ConnetionString { get; }

        public BloodTestInforRepo(HospitalManagermentContext context, IConfiguration configuration)
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
        public void createBloodTestInfor(BloodTestInfor bloodTestInfor)
        {
            if (bloodTestInfor == null)
            {
                throw new ArgumentNullException(nameof(bloodTestInfor));
            }
            bloodTestInfor.isDelete = false;
            _context.Add(bloodTestInfor);
        }

        public void deleteBloodTestInfor(BloodTestInfor bloodTestInfor)
        {
            if (bloodTestInfor == null)
            {
                throw new ArgumentNullException();
            }
            bloodTestInfor.isDelete = true;
            _context.Update(bloodTestInfor);
        }

        public IEnumerable<BloodTestInfor> getAll()
        {
            var listBloodTestInfors = _context.bloodTestInfors.Where(x => x.isDelete == false).OrderByDescending(x => x.lastModified).ToList();
            return listBloodTestInfors;
        }

        public IEnumerable<BloodTestInfoShowWithPatientNameDTO> getAllWithPatientName()
        {
            var ListBloodTestInfo = new List<BloodTestInfoShowWithPatientNameDTO>();
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    ListBloodTestInfo = connection.Query<BloodTestInfoShowWithPatientNameDTO>("getListBloodTest",commandType: CommandType.StoredProcedure).ToList();
                    connection.Close(); 
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
            return ListBloodTestInfo;
        }

        public BloodTestInfor getById(int id)
        {
            return _context.bloodTestInfors.FirstOrDefault(x => x.bloodTestId == id && x.isDelete == false);
        }

        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void updateBloodTestInfor(BloodTestInfor bloodTestInfor)
        {
            if (bloodTestInfor == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(bloodTestInfor);
        }
    }
}
