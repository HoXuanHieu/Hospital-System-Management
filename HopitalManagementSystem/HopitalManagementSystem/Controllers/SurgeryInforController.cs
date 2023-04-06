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
    public class SurgeryInforController : ControllerBase
    {
        private readonly ISurgeryInforRepo _repository;
        private readonly IMapper _mapper;

        public SurgeryInforController(ISurgeryInforRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SurgeryInforShowDTO>> getAllSurgeryInfors()
        {
            var surgeryInfor = _repository.getAll();
            return Ok(_mapper.Map<IEnumerable<SurgeryInforShowDTO>>(surgeryInfor));
        }

        [HttpGet("{id}", Name = "GetSurgeryInforById")]
        public ActionResult<SurgeryInforShowDTO> GetSurgeryInforById(int id)
        {
            var surgeryInfor = _repository.getById(id);

            if (surgeryInfor == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SurgeryInforShowDTO>(surgeryInfor));
        }
        [HttpPut("{id}")]
        public ActionResult<SurgeryInfor> PutSurgeryInfor([FromRoute] int id, SurgeryInforUpdateDTO surgeryInforUpdateDTO)
        {
            var surgeryInforRepo = _repository.getById(id);
            if (surgeryInforRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(surgeryInforUpdateDTO, surgeryInforRepo);
            surgeryInforRepo.lastModified = DateTime.Now;
            _repository.updateSurgeryInfor(surgeryInforRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpPost]
        public ActionResult<SurgeryInforCreateDTO> PostSurgeryInfor(SurgeryInforCreateDTO surgeryInforCreateDTO)
        {

            var surgeryInfor = _mapper.Map<SurgeryInfor>(surgeryInforCreateDTO);
            surgeryInfor.lastModified = DateTime.Now;
            _repository.createSurgeryInfor(surgeryInfor);
            _repository.saveChange();

            return Ok(NoContent());

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteSurgeryInfor(int id)
        {
            var surgeryInfor = _repository.getById(id);
            if (surgeryInfor == null)
            {
                return NotFound();
            }
            _repository.deleteSurgeryInfor(surgeryInfor);
            _repository.saveChange();

            return NoContent();
        }
    }
}
