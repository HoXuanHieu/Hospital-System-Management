using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepo _repository;
        private readonly IMapper _mapper;

        public StaffController(IStaffRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("Doctor")]
        public ActionResult<IEnumerable<StaffShowDTO>> getAllDoctor()
        {
            var staff = _repository.getAll().Where(x => x.role == "Doctor");
            return Ok(_mapper.Map<IEnumerable<StaffShowDTO>>(staff));
        }
        [HttpGet("DoctorDapper")]
        public ActionResult<IEnumerable<StaffShowDTO>> getAllDoctorbySQlString()
        {
            var doctor = _repository.getAllBySql();
            return Ok(_mapper.Map<IEnumerable<StaffShowDTO>>(doctor));
        }
        [HttpGet("getSurgeryDoctor")]
        public ActionResult<IEnumerable<StaffShowDTO>> getAllSurgeryDoctor()
        {
            var doctor = _repository.getAllSurgeryDoctor();
            return Ok(_mapper.Map<IEnumerable<StaffShowDTO>>(doctor));
        }
        [HttpGet("Employee")]
        public ActionResult<IEnumerable<StaffShowDTO>> getAllEmployee()
        {
            var staff = _repository.getAll().Where(x => x.role == "Doctor");
            return Ok(_mapper.Map<IEnumerable<StaffShowDTO>>(staff));
        }
        [HttpGet("{id}", Name = "GetStaffById")]
        public ActionResult<StaffShowDTO> GetStaffById(int id)
        {
            var staff = _repository.getById(id);

            if (staff == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StaffShowDTO>(staff));
        }
        [HttpPut("{id}")]
        public ActionResult<Staff> PutStaff([FromRoute] int id, StaffUpdateDTO staffUpdateDTO)
        {
            var staffRepo = _repository.getById(id);
            if (staffRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(staffUpdateDTO, staffRepo);
            staffRepo.lastAccess = DateTime.Now;
            _repository.updateStaff(staffRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpPost]
        public ActionResult<StaffCreateDTO> PostStaff(StaffCreateDTO staffCreateDTO)
        {
            var staff = _mapper.Map<Staff>(staffCreateDTO);
            staff.lastAccess = DateTime.Now;
            _repository.createStaff(staff);
            _repository.saveChange();

            return Ok(NoContent());

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStaff(int id)
        {
            var staff = _repository.getById(id);
            if (staff == null)
            {
                return NotFound();
            }
            _repository.deleteStaff(staff);
            _repository.saveChange();

            return NoContent();
        }
        [HttpGet("getStaffName/{id}")]
        public ActionResult GetStaff(int id)
        {
            var staff = _mapper.Map<StaffShowDTO>(_repository.getById(id));

            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff.staffName);
        }
        [HttpGet("GetStaffPagebySqlDapper/{pageNumber}/{pageSize}/{sortWith}/{search}/{status}")]
        public ActionResult<IEnumerable<StaffShowDTO>> GetStaffPagebySqlDapper([FromRoute] int pageNumber, [FromRoute] int pageSize, [FromRoute] string sortWith, [FromRoute] string search, [FromRoute] string status)
        {
            var staffListByPage = _mapper.Map<IEnumerable<StaffShowDTO>>(_repository.getSortListDoctorByDapper(search, sortWith, status, pageNumber, pageSize));
            if (staffListByPage == null)
            {
                return NotFound();
               
            }

            int maxPage = _repository.getTotalPage(search, pageSize);

            return Ok(new { staffListByPage, maxPage });
        }
        [HttpGet("getStaffpage/{pageNumber}/{pageSize}/{sortWith}/{search}/{status}")]
        public ActionResult<IEnumerable<StaffShowDTO>> GetStaffPage([FromRoute] int pageNumber, [FromRoute] int pageSize, [FromRoute] string sortWith, [FromRoute] string search, [FromRoute] string status)
        {
            var staffListByPage = _repository.getSortListDoctor(search, sortWith, status, pageNumber, pageSize);
            if (staffListByPage == null)
            {
                return NotFound();
            }
        
            int maxPage = _repository.getTotalPage(search, pageSize);
            
            return Ok(new { staffListByPage, maxPage });
        }
        [HttpPost("ImportExcel")]
        public ActionResult ImportExcel(List<StaffCreateDTO> doctors)
        {
            var doctorRepo = _mapper.Map<List<Staff>>(doctors);
            _repository.CreateListDoctor(doctorRepo);
            _repository.saveChange();
            return Ok();
        }

        [HttpGet("getDoctorByUserName/{userName}")]
        public ActionResult<StaffShowDTO> getDoctorByUserName(string userName)
        {
            var staff = _repository.getDoctorByUserName(userName);
            return Ok(_mapper.Map<StaffShowDTO>(staff));
        }
        [HttpGet("getDoctorByPhoneNumber/{phoneNumber}")]
        public ActionResult<StaffShowDTO> getDoctorByPhoneNumber(string phoneNumber)
        {
            var staff = _repository.getDoctorByPhoneNumber(phoneNumber);
            return Ok(_mapper.Map<StaffShowDTO>(staff));
        }
        [HttpGet("getDoctorByEmail/{email}")]
        public ActionResult<StaffShowDTO> getDoctorByEmail(string email)
        {
            var staff = _repository.getDoctorByEmail(email);
            return Ok(_mapper.Map<StaffShowDTO>(staff));
        }
    }
}
