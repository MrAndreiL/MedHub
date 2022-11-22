using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalSpecializationsController : ControllerBase
    {
        private readonly IRepository<MedicalSpeciality> medicalSpecialityRepository;

        public MedicalSpecializationsController(IRepository<MedicalSpeciality> medicalSpecialityRepository)
        {
            this.medicalSpecialityRepository = medicalSpecialityRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(medicalSpecialityRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateMedicalSpecialityDto medicalSpecialyDto)
        {
            var medicalSpeciality = new MedicalSpeciality(medicalSpecialyDto.SpecializationName);
            medicalSpecialityRepository.Add(medicalSpeciality);
            medicalSpecialityRepository.SaveChanges();
            return Created(nameof(Get), medicalSpeciality);
        }
    }
}
