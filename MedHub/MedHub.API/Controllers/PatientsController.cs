using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository<Patient> patientRepository;
        private readonly IRepository<MedicalRecord> medicalRecordRepository;
        private readonly IRepository<Allergen> allergenRepository;

        public PatientsController(IRepository<Patient> patientRepository, IRepository<MedicalRecord> medicalRecordRepository, IRepository<Allergen> allergenRepository)
        {
            this.patientRepository = patientRepository;
            this.medicalRecordRepository= medicalRecordRepository;
            this.allergenRepository= allergenRepository;
        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patients = patientRepository.GetAll().Select(p => new PatientDto()
            {
                Id = p.Id,
                CNP = p.CNP,
                FirstName= p.FirstName,
                LastName= p.LastName,
                Email = p.Email,
                MedicalHistory = p.MedicalHistory,
                Allergies = p.Allergies
            });

            return Ok(patients);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePatientDto patientDto)
        {
            var patient = Patient.Create(patientDto.CNP, patientDto.FirstName, patientDto.LastName, patientDto.Email);

            if (patient.IsSuccess)
            {
                patientRepository.Add(patient.Entity);
                patientRepository.SaveChanges();

                return Created(nameof(GetAllPatients), patient.Entity);
            }

            return BadRequest(patient.Error);
        }

        [HttpPost("{patientId}/add-allergens")]
        public IActionResult AddAllergensToPatient(Guid patientId, [FromBody] List<AllergenDto> allergensDtos)
        {
            var allergens = allergensDtos.Select(allergen => Allergen.Create(allergen.Name)).ToList();

            if (allergens.Any(a => a.IsFailure))
            {
                return BadRequest();
            }

            var patient = patientRepository.GetAll().Single(p => p.Id == patientId);

            if (patient == null)
            {
                return NotFound();
            }

            var result = patient.RecordAllergyList(allergens.Select(a => a.Entity).ToList());

            allergens.ForEach(a => allergenRepository.Add(a.Entity));
            patientRepository.SaveChanges();
            allergenRepository.SaveChanges();

            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }
    }
}