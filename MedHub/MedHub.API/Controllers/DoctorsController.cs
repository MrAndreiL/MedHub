using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
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
            var doctor = Doctor.Create(doctorDto.CNP, doctorDto.FirstName, doctorDto.LastName, doctorDto.Email);

            if (doctor.IsSuccess)
            {
                doctorRepository.Add(doctor.Entity);
                doctorRepository.SaveChanges();

                var fullDoctor = new DoctorDto
                {
                    Id = doctor.Entity.Id,
                    CNP= doctor.Entity.CNP,
                    FirstName= doctor.Entity.FirstName,
                    LastName= doctor.Entity.LastName,
                    Email= doctor.Entity.Email
                };

                return Created(nameof(Get), fullDoctor);
            }

            return BadRequest(doctor.Error);
        }
    }
}
