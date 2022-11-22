using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
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

        [HttpPost]
        public IActionResult Post([FromBody] CreateDoctorDto doctorDto)
        {
            var doctor = new Doctor(doctorDto.CNP, doctorDto.FirstName, doctorDto.LastName, doctorDto.Email);
            doctorRepository.Add(doctor);
            doctorRepository.SaveChanges();
            return Created(nameof(Get), doctor);
        }
    }
}
