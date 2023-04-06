using AutoMapper;
using HospitalManagementSystem.DTO;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepo _repository;
        private readonly IMapper _mapper;
        List<Medicine> _list= new List<Medicine>();
        public MedicineController(IMedicineRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MedicineShowDTO>> getAllMedicines()
        {
            var medicine = _repository.getAll();
            return Ok(_mapper.Map<IEnumerable<MedicineShowDTO>>(medicine));
        }
        
        [HttpPost]
        public ActionResult<MedicineCreateDTO> PostMedicine(MedicineCreateDTO medicine)
        {

            var medicineRepo = _mapper.Map<Medicine>(medicine);
            medicineRepo.lastModified = DateTime.Now;
            _repository.createMedicine(medicineRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpPost("ImportExcel")]
        public ActionResult ImportExcel(List<MedicineCreateDTO> medicines)
        {
            var medicineRepo = _mapper.Map<List<Medicine>>(medicines);
            _repository.CreateListMedicine(medicineRepo);
            _repository.saveChange();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteBloodTestInfor(int id)
        {
            var medicineRepo = _repository.getById(id);
            if (medicineRepo == null)
            {
                return NotFound();
            }
            _repository.deleteMedicine(medicineRepo);
            _repository.saveChange();

            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult<MedicineShowDTO> PutBloodTestInfor([FromRoute] int id, MedicineCreateDTO medicineUpdateDTO)
        {
            var medicineRepo = _repository.getById(id);
            if (medicineRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(medicineUpdateDTO, medicineRepo);
            medicineRepo.lastModified = DateTime.Now;
            _repository.updateMedicine(medicineRepo);
            _repository.saveChange();

            return Ok(NoContent());
        }
        [HttpGet("getByName/{name}")]
        public ActionResult<MedicineShowDTO> getByName(string name) {

            var medicine = _repository.getByNam(name);
            return Ok(_mapper.Map<MedicineShowDTO>(medicine));
        }
    }
}
