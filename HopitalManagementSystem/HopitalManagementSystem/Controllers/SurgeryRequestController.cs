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
    public class SurgeryRequestController : ControllerBase
    {
        private readonly ISurgeryRequestRepo _repository;
        private readonly IMapper _mapper;

        public SurgeryRequestController(ISurgeryRequestRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SurgeryRequestShowDTO>> getAllSurgeryRequests()
        {
            var surgeryRequest = _repository.getAll();
            return Ok(_mapper.Map<IEnumerable<SurgeryRequestShowDTO>>(surgeryRequest));
        }
        [HttpGet("getListWithName")]
        public ActionResult<IEnumerable<SurgeryRequestWithNameDTO>> getAllSurgeryRequestsWithName()
        {
            var result = _repository.getAllWithName();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("getSurgeryRequestbyStaffId/{id}")]
        public ActionResult<IEnumerable<SurgeryRequestWithNameDTO>> getSurgeryRequestbyStaffId(int id)
        {
            var result = _repository.getSurgeryRequestbyStaffId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}", Name = "GetSurgeryRequestById")]
        public ActionResult<SurgeryRequestShowDTO> GetSurgeryRequestById(int id)
        {
            var surgeryRequest = _repository.getById(id);

            if (surgeryRequest == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SurgeryRequestShowDTO>(surgeryRequest));
        }
        [HttpPut("{id}")]
        public ActionResult<SurgeryRequest> PutSurgeryRequest([FromRoute] int id, SurgeryRequestUpdateDTO surgeryRequestUpdateDTO)
        {
            var surgeryRequestRepo = _repository.getById(id);
            if (surgeryRequestRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(surgeryRequestUpdateDTO, surgeryRequestRepo);
            surgeryRequestRepo.lastModified = DateTime.Now;
            _repository.updateSurgeryRequest(surgeryRequestRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpPost]
        public ActionResult<SurgeryRequestCreateDTO> PostSurgeryRequest(SurgeryRequestCreateDTO surgeryRequestCreateDTO)
        {

            var surgeryRequest = _mapper.Map<SurgeryRequest>(surgeryRequestCreateDTO);
            surgeryRequest.lastModified = DateTime.Now;
            _repository.createSurgeryRequest(surgeryRequest);
            _repository.saveChange();

            return Ok(NoContent());

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteSurgeryRequest(int id)
        {
            var surgeryRequest = _repository.getById(id);
            if (surgeryRequest == null)
            {
                return NotFound();
            }
            _repository.deleteSurgeryRequest(surgeryRequest);
            _repository.saveChange();

            return NoContent();
        }
    }
}
