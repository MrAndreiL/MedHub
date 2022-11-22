using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository<Patient> patientRepository;

        public PatientsController(IRepository<Patient> patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(patientRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePatientDto patientDto)
        {
            var patient = new Patient(patientDto.CNP, patientDto.FirstName, patientDto.LastName, patientDto.Email);
            patientRepository.Add(patient);
            patientRepository.SaveChanges();
            return Created(nameof(Get), patient);
        }
    }
}
