using FluentAssertions;
using MedHub.API.DTOs;

using System.Net.Http.Json;

namespace MedHub.IntegrationTests
{
    public class PatientControllerTests: BaseIntegrationTests, IDisposable
    {
        private const string ApiURL = "v1/api/patients";
        /*
        [Fact]
        public async void When_RegisteringMedicalHistoryToPatient_ThenPatientMedicalHistoryShouldBeUpdated()
        {
            // Arrange
            var medicalRecordDtos = new List<CreateMedicalRecordDto>() {
                new CreateMedicalRecordDto() { MedicalNote = "a medical note from a real doctor"},
                new CreateMedicalRecordDto() { MedicalNote = "another medical note from a real doctor"},
            };

            var patientDto = CreateSUT();

            var createPatientResponse = await HttpClient.PostAsJsonAsync(ApiURL, patientDto);
            var patient = createPatientResponse.Content.ReadFromJsonAsync<PatientDto>();

            // Act
            var registerMedicalHistoryResponse = await HttpClient.PostAsJsonAsync
                ($"{ApiURL}/{patient.Id}/add-medical-history", medicalRecordDtos);

            // Assert
            createPatientResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            registerMedicalHistoryResponse.EnsureSuccessStatusCode();
            registerMedicalHistoryResponse.Content.Should().Be(System.Net.HttpStatusCode.NoContent);

        }
        */
        private static CreatePatientDto CreateSUT()
        {
            // Arrange
            return new CreatePatientDto
            {
                CNP = "1950430000000",
                FirstName = "Florin - Marian",
                LastName = "Hazi",
                Email = "haziflorinmarian@gmail.com",
            };
        }

        public void Dispose()
        {
            CleanDatabases();
        }
    }
}