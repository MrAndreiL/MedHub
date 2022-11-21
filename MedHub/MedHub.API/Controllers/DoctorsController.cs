using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IRepository<Doctor> doctorRepository;

        public DoctorsController(IRepository<Doctor> doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(doctorRepository.GetAll());
        }
    }
}
