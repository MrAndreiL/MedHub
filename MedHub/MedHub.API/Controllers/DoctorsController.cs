using MedHub.API.DTOs;
using MedHub.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MyShop.Infrastructure;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public DoctorsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }       

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var doctors = unitOfWork.DoctorRepository.GetAll().Select(d => new DoctorDto()
            {
                Id = d.Id,
                CNP = d.CNP,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
                Specializations = d.Specializations,
                Cabinets = d.Cabinets
            });

            return Ok(doctors);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateDoctorDto doctorDto)
        {
            var doctor = Doctor.Create(doctorDto.CNP, doctorDto.FirstName, doctorDto.LastName, doctorDto.Email);

            if (doctor.IsSuccess)
            {
                unitOfWork.DoctorRepository.Add(doctor.Entity);
                unitOfWork.DoctorRepository.SaveChanges();

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
        [HttpPatch("{doctorId:guid}/change-cabinet")]
        public IActionResult ChangeDoctorCabinet(Guid doctorId, [FromBody] CabinetDto cabinetDto)
        {
            var doctor = unitOfWork.DoctorRepository.GetAll().Single(p => p.Id == doctorId);
            var cabinet = unitOfWork.CabinetRepository.GetAll().Single(p => p.Id == cabinetDto.Id);

            if (doctor == null)
            {
                return NotFound();
            }
            if (cabinet == null)
            {
                return NotFound();
            }
            doctor.SetCabinetToDoctor(cabinet);
            cabinet.AddDoctorToCabinet(doctor);
            unitOfWork.DoctorRepository.Update(doctor);
            unitOfWork.CabinetRepository.Update(cabinet);
            unitOfWork.DoctorRepository.SaveChanges();
            unitOfWork.CabinetRepository.SaveChanges();
            return Ok();

        }

        [HttpPost("{doctorId:guid}/add-specializations")]
        public IActionResult AddSpecializationsToDoctor(Guid doctorId, [FromBody] MedicalSpecialitiesDto specializationsDto)
        {
            if (!specializationsDto.Ids.Any())
            {
                return BadRequest("Please submit specialization IDs!");
            }

            foreach (Guid specialityId in specializationsDto.Ids)
            {
                if (unitOfWork.MedicalSpecialityRepository.GetById(specialityId) == null)
                {
                    return BadRequest($"The Id {specialityId} does not exist in the database.");
                }
            }

            var doctor = unitOfWork.DoctorRepository.GetAll().Single(p => p.Id == doctorId);

            specializationsDto.Ids.ForEach(id =>
            {
                var specialization = unitOfWork.MedicalSpecialityRepository.GetById(id);

                doctor.AddSpecialization(specialization);
                specialization.Doctor.Add(doctor);

                unitOfWork.MedicalSpecialityRepository.Update(specialization);
            });

            unitOfWork.DoctorRepository.Update(doctor);
            unitOfWork.DoctorRepository.SaveChanges();

            unitOfWork.MedicalSpecialityRepository.SaveChanges();

            return NoContent();
        }


        [HttpPost("{doctorId:guid}/{patientId:guid}/add-medical-history")]
        public IActionResult RegisterMedicalHistoryToPatient(Guid doctorId, Guid patientId, [FromBody] List<MedicalRecordDto> medicalRecordDtos)
        {
            var doctor = unitOfWork.DoctorRepository.GetAll().Single(p => p.Id == doctorId);
            var patient = unitOfWork.PatientRepository.GetAll().Single(p => p.Id == patientId);

            if (doctor == null || patient == null)
            {
                return NotFound();
            }

            var medicalRecords = medicalRecordDtos.Select(m => MedicalRecord.Create(doctor, patient, m.MedicalNote)).ToList();

            if (medicalRecords.Any(m => m.IsFailure))
            {
                return BadRequest();
            }

            var result = patient.PushMedicalHistory(medicalRecords.Select(m => m.Entity).ToList());

            medicalRecords.ForEach(m => unitOfWork.MedicalRecordRepository.Add(m.Entity));
            unitOfWork.MedicalRecordRepository.SaveChanges();

            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }
    }
}