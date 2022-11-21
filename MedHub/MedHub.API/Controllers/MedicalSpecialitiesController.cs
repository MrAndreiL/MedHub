using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalSpecialitiesController : ControllerBase
    {
        private readonly IRepository<MedicalSpeciality> medicalSpecialityRepository;

        public MedicalSpecialitiesController(IRepository<MedicalSpeciality> medicalSpecialityRepository)
        {
            this.medicalSpecialityRepository = medicalSpecialityRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(medicalSpecialityRepository.GetAll());
        }
    }
}
