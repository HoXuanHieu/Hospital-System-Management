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
    public class StaffRepo : IStaffRepo
    {
        private readonly HospitalManagermentContext _context;
        private readonly IConfiguration _configuration;
        public string ConnetionString { get; }
        public StaffRepo(HospitalManagermentContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            ConnetionString = configuration.GetConnectionString("DbConnection");
        }
        public void createStaff(Staff staff)
        {
            if (staff == null)
            {
                throw new ArgumentNullException(nameof(staff));
            }
            staff.isDelete = false;
            _context.Add(staff);
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnetionString);
            }
        }

        public void deleteStaff(Staff staff)
        {
            if (staff == null)
            {
                throw new ArgumentNullException();
            }
            staff.isDelete = true;
            _context.Update(staff);
        }

        public IEnumerable<Staff> getAll()
        {
            var listStaff = _context.staffs.Where(x => x.isDelete == false).OrderByDescending(x => x.lastAccess).ToList();
            return listStaff;
        }

        public IEnumerable<Staff> getAllBySql()
        {
            List<Staff> result = new List<Staff>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    result = dbConnection.Query<Staff>("selectAllDoctors", commandType: CommandType.StoredProcedure).ToList();
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

        public Staff getById(int id)
        {
            return _context.staffs.FirstOrDefault(x => x.staffId == id && x.isDelete == false);

        }

        public IEnumerable<StaffDapperDTO> getSortListDoctorByDapper(string searchText, string sortBy, string status, int pageNumber, int pageSize)
        {
            var result = new List<StaffDapperDTO>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var values = new { searchText = searchText, sortByColumn = sortBy, sortOrder = status, pageNumber = pageNumber, pageSize = pageSize };
                    result = dbConnection.Query<StaffDapperDTO>("select_staff_data_for_page", values, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    Console.WriteLine("ok");

                    return result;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                Console.WriteLine(errorMsg);
                return null;
            }
        }
        public IEnumerable<Staff> getSortListDoctor(string searchText, string sortBy, string status, int pageNumber, int pageSize)
        {
            if (searchText == "none")
            {
                switch (sortBy)
                {
                    case "none":
                        var listStaffUnSort = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderByDescending(x => x.lastAccess).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                        return listStaffUnSort;
                    case "staffName":
                        if (status == "asc")
                        {
                            var listStaffByName = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderBy(x => x.staffName).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByName;
                        }
                        else if (status == "desc")
                        {
                            var listStaffByName = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderByDescending(x => x.staffName).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByName;
                        }
                        break;
                    case "gender":
                        if (status == "asc")
                        {
                            var listStaffByGender = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderBy(x => x.gender).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByGender;
                        }
                        else if (status == "desc")
                        {
                            var listStaffByGender = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderByDescending(x => x.gender).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByGender;
                        }
                        break;
                    case "age":
                        if (status == "asc")
                        {
                            var listStaffByAge = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderBy(x => x.age).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByAge;
                        }
                        else if (status == "desc")
                        {
                            var listStaffByAge = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderByDescending(x => x.age).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByAge;
                        }
                        break;

                    case "department":
                        if (status == "asc")
                        {
                            var listStaffByDepartment = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderBy(x => x.department).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByDepartment;
                        }
                        else if (status == "desc")
                        {
                            var listStaffByDepartment = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderByDescending(x => x.department).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByDepartment;
                        }
                        break;

                    case "specialization":
                        if (status == "asc")
                        {
                            var listStaffBySpecialization = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderBy(x => x.specialization).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffBySpecialization;
                        }
                        else if (status == "desc")
                        {
                            var listStaffBySpecialization = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderByDescending(x => x.specialization).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffBySpecialization;
                        }
                        break;

                    case "phoneNumber":
                        if (status == "asc")
                        {
                            var listStaffByPhoneNumber = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderBy(x => x.phoneNumber).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByPhoneNumber;
                        }
                        else if (status == "desc")
                        {
                            var listStaffByPhoneNumber = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderByDescending(x => x.phoneNumber).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByPhoneNumber;
                        }
                        break;
                    case "address":
                        if (status == "asc")
                        {
                            var listStaffByAddress = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderBy(x => x.address).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByAddress;
                        }
                        else if (status == "desc")
                        {
                            var listStaffByAddress = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderByDescending(x => x.address).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByAddress;
                        }
                        break;
                    case "email":
                        if (status == "asc")
                        {
                            var listStaffByEmail = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderBy(x => x.email).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByEmail;
                        }
                        else if (status == "desc")
                        {
                            var listStaffByEmail = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderByDescending(x => x.email).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                            return listStaffByEmail;
                        }
                        break;
                }
            }
            else
            {
                var listStaff = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").
                    OrderByDescending(x => x.lastAccess).
                    Where(x =>
                    x.staffName.Contains(searchText) ||
                    x.age.ToString().Contains(searchText) ||
                    x.gender.Contains(searchText) ||
                    x.department.Contains(searchText) ||
                    x.specialization.Contains(searchText) ||
                    x.phoneNumber.Contains(searchText) ||
                    x.address.Contains(searchText) ||
                    x.email.Contains(searchText)
                    ).
                    Skip((pageNumber - 1) * pageSize).Take(pageSize).
                    ToList();
                return listStaff;
            }
            return null;
        }
        public int getTotalPage(string searchText, int pageSize)
        {
            int totalItem = 0;
            int maxPage = 0;
            if (searchText == "none")
            {
                totalItem = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").OrderByDescending(x => x.lastAccess).Count();
            }
            else
            {
                totalItem = _context.staffs.Where(x => x.isDelete == false && x.role == "Doctor").
                   OrderByDescending(x => x.lastAccess).
                   Where(x =>
                   x.staffName.Contains(searchText) ||
                   x.age.ToString().Contains(searchText) ||
                   x.gender.Contains(searchText) ||
                   x.department.Contains(searchText) ||
                   x.specialization.Contains(searchText) ||
                   x.phoneNumber.Contains(searchText) ||
                   x.address.Contains(searchText) ||
                   x.email.Contains(searchText)).Count();
            }
            if (totalItem % pageSize == 0)
            {
                maxPage = totalItem / pageSize;
            }
            else
            {
                maxPage = totalItem / pageSize + 1;
            }

            return maxPage;
        }
        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void updateStaff(Staff staff)
        {
            if (staff == null)
            {
                throw new ArgumentNullException();
            }
            _context.Update(staff);
        }

        public IEnumerable<Staff> getAllSurgeryDoctor()
        {
            List<Staff> result = new List<Staff>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    result = dbConnection.Query<Staff>("getSurgeryDoctor", commandType: CommandType.StoredProcedure).ToList();
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

        public void CreateListDoctor(List<Staff> doctors)
        {
            if (doctors == null)
            {
                throw new ArgumentException();
            }
            foreach (var doctor in doctors)
            {

                doctor.lastAccess = DateTime.Now;
                doctor.role = "Doctor";
                doctor.password = RandomString();
                doctor.isDelete = false;
                _context.staffs.Add(doctor);
            }
        }
        public string RandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public Staff getDoctorByUserName(string userName)
        {
            return _context.staffs.FirstOrDefault(x => x.userName == userName && x.isDelete == false);
        }

        public Staff getDoctorByPhoneNumber(string phoneNumber)
        {
            return _context.staffs.FirstOrDefault(x => x.phoneNumber == phoneNumber && x.isDelete == false);
        }

        public Staff getDoctorByEmail(string email)
        {
            return _context.staffs.FirstOrDefault(x => x.email == email && x.isDelete == false);

        }
    }

}
