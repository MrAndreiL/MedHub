using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CabinetsController : ControllerBase
    {
        private readonly IRepository<Cabinet> cabinetRepository;
        private readonly IRepository<Doctor> doctorRepository;

        public CabinetsController(IRepository<Cabinet> cabinetRepository, IRepository<Doctor> doctorRepository)
        {
            this.cabinetRepository = cabinetRepository;
            this.doctorRepository = doctorRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(cabinetRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCabinetDto cabinetDto)
        {
            var cabinet = Cabinet.Create(cabinetDto.Address);
            if (cabinet.IsSuccess)
            {
                cabinetRepository.Add(cabinet.Entity);
                cabinetRepository.SaveChanges();

                var fullCabinet = new CabinetDto
                {
                    Id = cabinet.Entity.Id,
                    Address= cabinet.Entity.Address
                };

                return Created(nameof(Get), fullCabinet);
            }

            return BadRequest(cabinet.Error);
        }
        [HttpPost("{cabinetId}/add-doctors")]
        public IActionResult AddDoctorsToCabinet(Guid cabinetId,[FromBody] List<CreateDoctorDto> doctorsDtos)
        {
            
            var doctors = doctorsDtos.Select(doctor => Doctor.Create(doctor.CNP,doctor.FirstName,doctor.LastName, doctor.Email)).ToList();

            if (doctors.Any(a => a.IsFailure))
            {
                return BadRequest();
            }

            var cabinet = cabinetRepository.GetAll().Single(p => p.Id == cabinetId);

            if (cabinet == null)
            {
                return NotFound();
            }

            var result = cabinet.AddDoctorsListToCabinet(doctors.Select(a => a.Entity).ToList());

            doctors.ForEach(a => doctorRepository.Add(a.Entity));
            doctorRepository.SaveChanges();
            cabinetRepository.SaveChanges();

            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }
       
    }
}
