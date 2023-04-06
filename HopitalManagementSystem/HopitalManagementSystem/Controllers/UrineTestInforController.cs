using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrineTestInforController : ControllerBase
    {
        private readonly IUrineTestInforRepo _repository;
        private readonly IMapper _mapper;

        public UrineTestInforController(IUrineTestInforRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UrineTestInforShowDTO>> getAllUrineTestInfors()
        {
            var urineTestInfor = _repository.getAll();
            return Ok(_mapper.Map<IEnumerable<UrineTestInforShowDTO>>(urineTestInfor));
        }
        [HttpGet("getListWithPatientName")]
        public ActionResult<IEnumerable<UrineTestInforShowWithPatientName>> getAllUrineTestInforstWithPatientName()
        {

            var urinetestInfors = _repository.getAllWithPatientName();
            if (urinetestInfors == null)
            {
                return NotFound();
            }
            return Ok(urinetestInfors);
        }

        [HttpGet("{id}", Name = "GetUrineTestInforById")]
        public ActionResult<UrineTestInforShowDTO> GetUrineTestInforById(int id)
        {
            var urineTestInfor = _repository.getById(id);

            if (urineTestInfor == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UrineTestInforShowDTO>(urineTestInfor));
        }
        [HttpPut("{id}")]
        public ActionResult<UrineTestInfor> PutUrineTestInfor([FromRoute] int id, UrineTestInforUpdateDTO urineTestInforUpdateDTO)
        {
            var urineTestInforRepo = _repository.getById(id);
            if (urineTestInforRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(urineTestInforUpdateDTO, urineTestInforRepo);
            urineTestInforRepo.lastModified = DateTime.Now;
            _repository.updateUrineTestInfor(urineTestInforRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpPost]
        public ActionResult<UrineTestInforCreateDTO> PostUrineTestInfor(UrineTestInforCreateDTO urineTestInforCreateDTO)
        {

            var urineTestInfor = _mapper.Map<UrineTestInfor>(urineTestInforCreateDTO);
            urineTestInfor.lastModified = DateTime.Now;
            _repository.createUrineTestInfor(urineTestInfor);
            _repository.saveChange();

            return Ok(NoContent());

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUrineTestInfor(int id)
        {
            var urineTestInfor = _repository.getById(id);
            if (urineTestInfor == null)
            {
                return NotFound();
            }
            _repository.deleteUrineTestInfor(urineTestInfor);
            _repository.saveChange();

            return NoContent();
        }
    }
}
