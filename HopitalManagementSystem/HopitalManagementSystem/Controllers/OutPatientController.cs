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
    public class OutPatientController : ControllerBase
    {
        private readonly IOutPatientRepo _repository;
        private readonly IMapper _mapper;

        public OutPatientController(IOutPatientRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OutPatientShowDTO>> getAllOutPatients()
        {
            var outPatient = _repository.getAll();
            return Ok(_mapper.Map<IEnumerable<OutPatientShowDTO>>(outPatient));
        }

        [HttpGet("{id}", Name = "GetOutPatientById")]
        public ActionResult<OutPatientShowDTO> GetOutPatientById(int id)
        {
            var outPatient = _repository.getById(id);

            if (outPatient == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OutPatientShowDTO>(outPatient));
        }
        [HttpGet("getOutPatientListByIdWithDoctorName/{id}")]
        public ActionResult<IEnumerable<OutPatientShowWithDoctorName>> getOutPatientListByIdWithDoctorName(int id)
        {
            var outPatients = _repository.getOutPatientListByIdWithDoctorName(id);
            return Ok(outPatients);
        }
        [HttpGet("getOutPatientListById/{id}")]
        public ActionResult<IEnumerable<OutPatientShowDTO>> getOutPatientListById(int id)
        {
            var outPatients = _repository.getOutPatientListById(id);
            return Ok(_mapper.Map<IEnumerable<OutPatientShowDTO>>(outPatients));
        }

        [HttpGet("getOutPatientListByDepartment/{department}")]
        public ActionResult<IEnumerable<InPatientShowbyDepartment>> getOutPatientListByDepartment(string department)
        {
            var outPatients = _repository.getOutPatientListByDepartment(department);
            if (outPatients == null)
            {
                return NotFound();
            }
            return Ok(outPatients);
        }
        [HttpPut("{id}")]
        public ActionResult<OutPatient> PutOutPatient([FromRoute] int id, OutPatientUpdateDTO outPatientUpdateDTO)
        {
            var outPatientRepo = _repository.getById(id);
            if (outPatientRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(outPatientUpdateDTO, outPatientRepo);
            outPatientRepo.lastModified = DateTime.Now;
            _repository.updateOutPatient(outPatientRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpPost]
        public ActionResult<OutPatientCreateDTO> PostOutPatient(OutPatientCreateDTO outPatientCreateDTO)
        {

            var outPatient = _mapper.Map<OutPatient>(outPatientCreateDTO);
            outPatient.lastModified = DateTime.Now;
            _repository.createOutPatient(outPatient);
            _repository.saveChange();

            return Ok(NoContent());

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteOutPatient(int id)
        {
            var outPatient = _repository.getById(id);
            if (outPatient == null)
            {
                return NotFound();
            }
            _repository.deleteOutPatient(outPatient);
            _repository.saveChange();

            return NoContent();
        }
    }
}
