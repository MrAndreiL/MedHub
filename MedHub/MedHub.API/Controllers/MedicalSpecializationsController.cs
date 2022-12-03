using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
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
            var medicalSpeciality = MedicalSpeciality.Create(medicalSpecialyDto.SpecializationName);

            if (medicalSpeciality.IsSuccess)
            {
                medicalSpecialityRepository.Add(medicalSpeciality.Entity);
                medicalSpecialityRepository.SaveChanges();

                var fullMedicalSpeciality = new MedicalSpecialityDto
                {
                    Id = medicalSpeciality.Entity.Id,
                    SpecializationName = medicalSpeciality.Entity.SpecializationName
                };
                
                return Created(nameof(Get), fullMedicalSpeciality);
            }

            return BadRequest(medicalSpeciality.Error);
        }
    }
}
