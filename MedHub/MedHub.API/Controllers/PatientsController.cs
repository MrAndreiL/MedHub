using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository<Patient> patientRepository;
        private readonly IRepository<MedicalRecord> medicalRecordRepository;
        private readonly IRepository<Allergen> allergenRepository;

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

        [HttpPost("{patientId}/add-medical-history")]
        public IActionResult RegisterMedicalHistory(Guid patientId, [FromBody] List<CreateMedicalRecordDto> medicalRecordDtos)
        {
            var medicalHistory = medicalRecordDtos.Select(medicalRecord => new MedicalRecord(medicalRecord.MedicalNote)).ToList();
            if (medicalHistory.Any(medicalRecord => medicalRecord == null))
            {
                return BadRequest();
            }
            var patient = patientRepository.Get(patientId);
            if (patient == null)
            {
                return NotFound();
            }

            var result = patient.PushMedicalHistory(medicalHistory);
            medicalHistory.ForEach(medicalRecord => medicalRecordRepository.Add(medicalRecord));

            patientRepository.SaveChanges();
            medicalRecordRepository.SaveChanges();

            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }

        [HttpPost("{patientId}/add-allergens")]
        public IActionResult AddAllergensToPatient(Guid patientId, [FromBody] List<CreateAllergenDto> allergensDtos)
        {
            var allergens = allergensDtos.Select(allergen => new Allergen(allergen.Name)).ToList();
            if (allergens.Any(allergen => allergen == null))
            {
                return BadRequest();
            }
            var patient = patientRepository.Get(patientId);
            if (patient == null)
            {
                return NotFound();
            }

            var result = patient.RecordAllergyList(allergens);
            allergens.ForEach(allergen => allergenRepository.Add(allergen));

            patientRepository.SaveChanges();
            allergenRepository.SaveChanges();

            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }
    }
}
