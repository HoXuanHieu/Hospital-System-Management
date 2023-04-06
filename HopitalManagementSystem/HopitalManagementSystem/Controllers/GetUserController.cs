using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        private readonly IStaffRepo _repository;
        private readonly IMapper _mapper;
        public GetUserController(IStaffRepo repository, IMapper mapper)
        {
            _mapper= mapper;
            _repository = repository;   
        }
        [HttpGet("user")]
        [Authorize]
        public ActionResult UserLogin()
        {
            var currentUser = GetCurrentUser();
            return Ok(currentUser);
        }

        private StaffShowDTO GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity !=  null)
            {
                var userClaim = identity.Claims;
                int id = Int32.Parse(userClaim.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value);
                var userReturn = _repository.getById(id);
                return _mapper.Map<StaffShowDTO>(userReturn);
            }
            return null;
        }
    }
}
