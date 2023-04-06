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
    public class PatientController : ControllerBase
    {

        private readonly IPatientRepo _repository;
        private readonly IMapper _mapper;

        public PatientController(IPatientRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientShowDTO>> getAllPatient()
        {
            var patients = _repository.getAll();
            return Ok(_mapper.Map<IEnumerable<PatientShowDTO>>(patients));
        }

        [HttpGet("{id}", Name = "GetPatientById")]
        public ActionResult<PatientShowDTO> GetPatientById(int id)
        {
            var patient = _repository.getById(id);

            if (patient == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PatientShowDTO>(patient));

        }

        [HttpPut("{id}")]
        public ActionResult<Patient> PutPatient([FromRoute] int id, PatientUpdateDTO patientUpdateDTO)
        {
            var patientRepo = _repository.getById(id);
            if (patientRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(patientUpdateDTO, patientRepo);
            patientRepo.lastModified = DateTime.Now;
            _repository.updatePatient(patientRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpPost]
        public ActionResult<PatientCreateDTO> PostPatient(PatientCreateDTO patientCreateDTO)
        {
            var patientNew = _mapper.Map<Patient>(patientCreateDTO);
            patientNew.lastModified = DateTime.Now;
            _repository.createPatient(patientNew);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePatient(int id)
        {
            var patient = _repository.getById(id);
            if (patient == null)
            {
                return NotFound();
            }
            _repository.deletePatient(patient);
            _repository.saveChange();

            return NoContent();
        }
    }
}
