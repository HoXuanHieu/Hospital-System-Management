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
    public class DischargeController : ControllerBase
    {
        private readonly IDishargeRepo _repository;
        private readonly IMapper _mapper;

        public DischargeController(IDishargeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DischargeShowDTO>> getAllDischarges()
        {
            var discharge = _repository.getAll();
            return Ok(_mapper.Map<IEnumerable<DischargeShowDTO>>(discharge));
        }

        [HttpGet("{id}", Name = "GetDischargeById")]
        public ActionResult<DischargeShowDTO> GetDischargeById(int id)
        {
            var discharge = _repository.getById(id);

            if (discharge == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DischargeShowDTO>(discharge));
        }
        [HttpPut("{id}")]
        public ActionResult<Discharge> PutDischarge([FromRoute] int id, DischargeUpdateDTO dischargeUpdateDTO)
        {
            var dischargeRepo = _repository.getById(id);
            if (dischargeRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(dischargeUpdateDTO, dischargeRepo);
            dischargeRepo.lastModified = DateTime.Now;
            _repository.updateDischarge(dischargeRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpPost]
        public ActionResult<DisChargeCreateDTO> PostDischarge(DisChargeCreateDTO dischargeCreateDTO)
        {

            var discharge = _mapper.Map<Discharge>(dischargeCreateDTO);
            discharge.lastModified= DateTime.Now; 
            _repository.createDischarge(discharge);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteDischarge(int id)
        {
            var discharge = _repository.getById(id);
            if (discharge == null)
            {
                return NotFound();
            }
            _repository.deleteDischarge(discharge);
            _repository.saveChange();

            return NoContent();
        }
    }
}
