using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IStaffRepo _repository;

        public LoginController(IConfiguration config, IStaffRepo repository)
        {
            _config = config;
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(StaffLogin userLogin)
        {

            if (userLogin == null)
            {
                return null;
            }
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);

            }
            return BadRequest("Not found");
        }

        private string Generate(Staff user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, user.staffId.ToString()),
                new Claim(ClaimTypes.Name, user.staffName),
            new Claim(ClaimTypes.NameIdentifier, user.userName),
            new Claim(ClaimTypes.MobilePhone, user.phoneNumber),
            new Claim(ClaimTypes.StreetAddress, user.address),
            new Claim(ClaimTypes.Email, user.email),
            new Claim(ClaimTypes.Role, user.role),
        };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Staff Authenticate(StaffLogin userLogin)
        {
            Staff userInRepo = _repository.getAll().FirstOrDefault(
        x => x.userName.ToLower() == userLogin.staffUserName.ToLower()
        && x.password == userLogin.password);
            if (userInRepo != null)
            {
                return userInRepo;
            }
            return null;
        }

    }
}
