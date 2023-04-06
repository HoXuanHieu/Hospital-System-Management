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
    public class UrineTestInforRepo : IUrineTestInforRepo
    {
        private readonly HospitalManagermentContext _context;
        private readonly IConfiguration _configuration;
        public string ConnetionString { get; }
        public UrineTestInforRepo(HospitalManagermentContext context, IConfiguration configuration)
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
        public void createUrineTestInfor(UrineTestInfor urineTestInfor, IConfiguration configuration)
        {
            if (urineTestInfor == null)
            {
                throw new ArgumentNullException(nameof(urineTestInfor));
            }
            urineTestInfor.isDelete = false;
            _context.Add(urineTestInfor);
        }

        public void deleteUrineTestInfor(UrineTestInfor urineTestInfor)
        {
            if (urineTestInfor == null)
            {
                throw new ArgumentNullException();
            }
            urineTestInfor.isDelete = true;
            _context.Update(urineTestInfor);
        }

        public IEnumerable<UrineTestInfor> getAll()
        {
            var listUrineTestInfor = _context.urineTestInfors.Where(x => x.isDelete == false).OrderByDescending(x => x.lastModified).ToList();
            return listUrineTestInfor;
        }

        public IEnumerable<UrineTestInforShowWithPatientName> getAllWithPatientName()
        {
            var LisUrineTestInfo = new List<UrineTestInforShowWithPatientName>();
            try
            {
                using (IDbConnection connection = Connection)
                {
                    connection.Open();
                    LisUrineTestInfo = connection.Query<UrineTestInforShowWithPatientName>("getListUrineTest", commandType: CommandType.StoredProcedure).ToList();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                return null;
            }
            return LisUrineTestInfo;
        }

        public UrineTestInfor getById(int id)
        {
            return _context.urineTestInfors.FirstOrDefault(x => x.urineTestId == id && x.isDelete == false);

        }

        public bool saveChange()
        {
              return (_context.SaveChanges() >= 0);

        }

        public void updateUrineTestInfor(UrineTestInfor urineTestInfor)
        {
            if (urineTestInfor == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(urineTestInfor);
        }

        public void createUrineTestInfor(UrineTestInfor urineTestInfor)
        {
            if (urineTestInfor == null)
            {
                throw new ArgumentNullException(nameof(urineTestInfor));
            }
            urineTestInfor.isDelete = false;
            _context.Add(urineTestInfor);
        }
    }
}
