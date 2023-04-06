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
    public class PharmacyInforController : ControllerBase
    {
        private readonly IPharmacyInforRepo _repository;
        private readonly IMapper _mapper;

        public PharmacyInforController(IPharmacyInforRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PharmacyInforShowDTO>> getAllPharmacyInfors()
        {
            var pharmacyInfor = _repository.getAll();
            return Ok(_mapper.Map<IEnumerable<PharmacyInforShowDTO>>(pharmacyInfor));
        }
        [HttpGet("getAllByDepartment/{department}")]
        public ActionResult<IEnumerable<PharmacyInforShowDTO>> getAllByDepartment(string department)
        {
            var pharmacyInfor = _repository.getAllByDepartment(department);
            if(pharmacyInfor == null)
            {
                return NotFound();
            }
            return Ok(pharmacyInfor);
        }
        [HttpGet("getAllByPatientId/{patientId}")]
        public ActionResult<IEnumerable<PharmacyInforShowDTO>> getAllByPatientId(int patientId)
        {
            var pharmacyInfor = _repository.getPharmacyByPatientId(patientId);
            if (pharmacyInfor == null)
            {
                return NotFound();
            }
            return Ok(pharmacyInfor);
        }
        [HttpGet("{id}", Name = "GetPharmacyInforById")]
        public ActionResult<PharmacyInforShowDTO> GetPharmacyInforById(int id)
        {
            var pharmacyInfor = _repository.getById(id);

            if (pharmacyInfor == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PharmacyInforShowDTO>(pharmacyInfor));
        }
        [HttpPut("{id}")]
        public ActionResult<PharmacyInfor> PutPharmacyInfor([FromRoute] int id, PharmacyInforUpdateDTO pharmacyInforUpdateDTO)
        {
            var pharmacyInforRepo = _repository.getById(id);
            if (pharmacyInforRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(pharmacyInforUpdateDTO, pharmacyInforRepo);
            pharmacyInforRepo.lastModified = DateTime.Now;
            _repository.updatePharmacyInfor(pharmacyInforRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpPost]
        public ActionResult<PharmacyInforCreateDTO> PostPharmacyInfor(PharmacyInforCreateDTO pharmacyInforCreateDTO)
        {

            var pharmacyInfor = _mapper.Map<PharmacyInfor>(pharmacyInforCreateDTO);
            pharmacyInfor.lastModified = DateTime.Now;
            _repository.createPharmacyInfor(pharmacyInfor);
            _repository.saveChange();

            return Ok(NoContent());

        }
        [HttpDelete("{id}")]
        public ActionResult DeletePharmacyInfor(int id)
        {
            var pharmacyInfor = _repository.getById(id);
            if (pharmacyInfor == null)
            {
                return NotFound();
            }
            _repository.deletePharmacyInfor(pharmacyInfor);
            _repository.saveChange();

            return NoContent();
        }
    }
}
