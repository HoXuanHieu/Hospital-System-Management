using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodTestInforController : ControllerBase
    {
        private readonly IBloodTestInforRepo _repository;
        private readonly IMapper _mapper;

        public BloodTestInforController(IBloodTestInforRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BloodTestInforShowDTO>> getAllBloodTestInfors()
        {
            var bloodtestInfors = _repository.getAll();
            return Ok(_mapper.Map<IEnumerable<BloodTestInforShowDTO>>(bloodtestInfors));
        }

        [HttpGet("getListWithPatientName")]
        public ActionResult<IEnumerable<BloodTestInfoShowWithPatientNameDTO>> getAllBloodTestInforstWithPatientName()
        {

            var bloodtestInfors = _repository.getAllWithPatientName();
            if(bloodtestInfors ==null)
            {
                return NotFound();
            }
            return Ok(bloodtestInfors);
        }
        [HttpGet("{id}", Name = "GetBloodTestInforById")]
        public ActionResult<BloodTestInforShowDTO> GetBloodTestInforById(int id)
        {
            var bloodTestInfor = _repository.getById(id);

            if (bloodTestInfor == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BloodTestInforShowDTO>(bloodTestInfor));
        }
        [HttpPut("{id}")]
        public ActionResult<BloodTestInfor> PutBloodTestInfor([FromRoute] int id, BloodTestInforUpdateDTO bloodTestInforUpdateDTO)
        {
            var bloodtestRepo = _repository.getById(id);
            if (bloodtestRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(bloodTestInforUpdateDTO, bloodtestRepo);
            bloodtestRepo.lastModified= DateTime.Now;
            _repository.updateBloodTestInfor(bloodtestRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpPost]
        public ActionResult<BloodTestinforCreateDTO> PostBloodTestInfor(BloodTestinforCreateDTO bloodTestinforCreateDTO)
        {

            var bloodTestInfor = _mapper.Map<BloodTestInfor>(bloodTestinforCreateDTO);
            bloodTestInfor.lastModified = DateTime.Now;
            _repository.createBloodTestInfor(bloodTestInfor);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteBloodTestInfor(int id)
        {
            var bloodTestInfor = _repository.getById(id);
            if (bloodTestInfor == null)
            {
                return NotFound();
            }
            _repository.deleteBloodTestInfor(bloodTestInfor);
            _repository.saveChange();

            return NoContent();
        }
    }
}
