using FluentAssertions;
using MedHub.API.DTOs;
using MedHub.Domain.Models;

using System.Net.Http.Json;

namespace MedHub.IntegrationTests
{
    public class PatientControllerTests: BaseIntegationTests
    {
        private const string RequestUri = "api/patients";

        [Fact]
        public async void When_RegisteringMedicalHistoryToPatient_ThenPatientMedicalHistoryShouldBeUpdated()
        {
            var medicalRecordDtos = new List<CreateMedicalRecordDto>() { 
                new CreateMedicalRecordDto(){ MedicalNote= "a medical note from a real doctor"},
                new CreateMedicalRecordDto(){ MedicalNote= "another medical note from a real doctor"},
            };
            var patientDto = new Patient("6221113017906", "Popescu", "Ion", "popescuion2222@mail.com");

            var createPatientResponse = await HttpClient.PostAsJsonAsync(RequestUri, patientDto);
            var patient = createPatientResponse.Content.ReadFromJsonAsync<Patient>();
            var registerMedicalHistoryResponse = await HttpClient.PostAsJsonAsync($"api/patients/{patient.Id}/add-medical-history", medicalRecordDtos);



            createPatientResponse.EnsureSuccessStatusCode();
            createPatientResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            registerMedicalHistoryResponse.Content.Should().Be(System.Net.HttpStatusCode.NoContent);

        }
    }
}