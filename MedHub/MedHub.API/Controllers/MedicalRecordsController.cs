using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IRepository<MedicalRecord> medicalRecordRepository;

        public MedicalRecordsController(IRepository<MedicalRecord> medicalRecordRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(medicalRecordRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMedicalRecordDto medicalRecordDto)
        {
            var medicalRecord = MedicalRecord.Create(medicalRecordDto.MedicalNote);
            if (medicalRecord.IsSuccess)
            {
                medicalRecordRepository.Add(medicalRecord.Entity);
                medicalRecordRepository.SaveChanges();
                return Created(nameof(Get), medicalRecord);
            }

            return BadRequest(medicalRecord.Error);
        }
    }
}
