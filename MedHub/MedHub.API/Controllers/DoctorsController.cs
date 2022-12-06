using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IRepository<Doctor> doctorRepository;
        private readonly IRepository<MedicalSpeciality> medicalSpecialityRepository;

        public DoctorsController(IRepository<Doctor> doctorRepository, IRepository<MedicalSpeciality> medicalSpecialityRepository)
        {
            this.doctorRepository = doctorRepository;
            this.medicalSpecialityRepository = medicalSpecialityRepository;
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var doctors = doctorRepository.GetAll().Select(d => new DoctorDto()
            {
                Id = d.Id,
                CNP = d.CNP,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
                Specializations = d.Specializations,
                Cabinet = d.Cabinet
            });

            return Ok(doctors);
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
                    CNP = doctor.Entity.CNP,
                    FirstName = doctor.Entity.FirstName,
                    LastName = doctor.Entity.LastName,
                    Email = doctor.Entity.Email
                };

                return Created(nameof(GetAllDoctors), fullDoctor);
            }

            return BadRequest(doctor.Error);
        }

        [HttpPost("{doctorId:guid}/add-specializations")]
        public IActionResult AddSpecializationsToDoctor(Guid doctorId, [FromBody] MedicalSpecialitiesDto specializationsDto)
        {
            if (!specializationsDto.Ids.Any())
            {
                return BadRequest("Please submit specialization IDs!");
            }

            foreach(Guid specialityId in specializationsDto.Ids) {
                if (medicalSpecialityRepository.GetById(specialityId) == null)
                {
                    return BadRequest($"The Id {specialityId} does not exist in the database.");
                }
            }

            var doctor = doctorRepository.GetAll().Single(p => p.Id == doctorId);

            specializationsDto.Ids.ForEach(id =>
            {
                var specialization = medicalSpecialityRepository.GetById(id);

                doctor.AddSpecialization(specialization);
                specialization.Doctors.Add(doctor);

                medicalSpecialityRepository.Update(specialization);
            });

            doctorRepository.Update(doctor);
            doctorRepository.SaveChanges();

            medicalSpecialityRepository.SaveChanges();

            return NoContent();
        }
    }
}
