using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult Post([FromBody] CreateMedicalRecordDto medicalRecordDto)
        {
            var medicalRecord = new MedicalRecord(medicalRecordDto.MedicalNote, DateTime.Now);
            medicalRecordRepository.Add(medicalRecord);
            medicalRecordRepository.SaveChanges();
            return Created(nameof(Get), medicalRecord);
        }
    }
}
