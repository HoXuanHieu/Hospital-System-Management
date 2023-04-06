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
    public class InPatientController : ControllerBase
    {
        private readonly IInPatientRepo _repository;
        private readonly IMapper _mapper;

        public InPatientController(IInPatientRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<InPatientShowDTO>> getAllInPatient()
        {
            var inPatient = _repository.getAll();
            return Ok(_mapper.Map<IEnumerable<InPatientShowDTO>>(inPatient));
        }

        [HttpGet("{id}", Name = "GetInPatientById")]
        public ActionResult<InPatientShowDTO> GetInPatientById(int id)
        {
            var inPatient = _repository.getById(id);

            if (inPatient == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<InPatientShowDTO>(inPatient));
        }
        [HttpGet("getInPatientListById/{id}")]
        public ActionResult<IEnumerable<InPatientShowDTO>> getInPatientListById(int id)
        {
            var inPatients = _repository.getInPatientListById(id);
            return Ok(_mapper.Map<IEnumerable<InPatientShowDTO>>(inPatients));
        }
        [HttpGet("getInPatientListByDepartment/{department}")]
        public ActionResult<IEnumerable<InPatientShowbyDepartment>> getInPatientListByDepartnment(string department)
        {
            var inPatients = _repository.getInPatientListByDepartment(department);
            if (inPatients == null)
            {
                return NotFound();
            }
            return Ok(inPatients);
        }
        [HttpGet("getInPatientListByIdWithDoctorName/{id}")]
        public ActionResult<IEnumerable<InPatientShowWithDoctorNameDTO>> getInPatientListByIdWithDoctorName(int id)
        {
            var inPatients = _repository.getInPatientListByIdWithDoctorName(id);
            return Ok(inPatients);
        }

        [HttpPut("{id}")]
        public ActionResult<InPatient> PutInPatient([FromRoute] int id, InPatientUpdateDTO inPatientUpdateDTO)
        {
            var inPatientRepo = _repository.getById(id);
            if (inPatientRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(inPatientUpdateDTO, inPatientRepo);
            inPatientRepo.lastModified= DateTime.Now;
            _repository.updateInPatient(inPatientRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }

        [HttpPost]
        public ActionResult<InPatientCreateDTO> PostInPatient(InPatientCreateDTO inPatientCreateDTO)
        {

            var inPatient = _mapper.Map<InPatient>(inPatientCreateDTO);
            inPatient.lastModified = DateTime.Now;
            _repository.createInPatient(inPatient);
            _repository.saveChange();

            return Ok(NoContent());

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteInPatient(int id)
        {
            var inPatient = _repository.getById(id);
            if (inPatient == null)
            {
                return NotFound();
            }
            _repository.deleteInPatient(inPatient);
            _repository.saveChange();

            return NoContent();
        }
    }
}
