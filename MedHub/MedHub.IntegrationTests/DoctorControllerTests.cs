using MedHub.API.DTOs;
using FluentAssertions;
using System.Net.Http.Json;

namespace MedHub.IntegrationTests
{
    public class DoctorControllerTests: BaseIntegrationTests, IDisposable
    {

        private const string ApiURL = "v1/api/doctors";

        [Fact]
        public async void WhenAddingSpecializationsToDoctor_ThenShouldUpdateDoctorSpecializations()
        {
            // Arrange
            var specializationsDto = new List<CreateMedicalSpecialityDto>() {
                new CreateMedicalSpecialityDto() { SpecializationName = "chirurg"},
                new CreateMedicalSpecialityDto() { SpecializationName = "dentist"},
            };
            var doctorDto = CreateSUT();

            var createDoctorResponse = await HttpClient.PostAsJsonAsync(ApiURL, doctorDto);
            var doctor = createDoctorResponse.Content.ReadFromJsonAsync<DoctorDto>();

            // Act
            var registerSpecializationsResponse = await HttpClient.PostAsJsonAsync
                ($"{ApiURL}/{doctor.Id}/add-specializations", specializationsDto);

            // Assert
            createDoctorResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            registerSpecializationsResponse.EnsureSuccessStatusCode();
            registerSpecializationsResponse.Content.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        private static CreateDoctorDto CreateSUT()
        {
            // Arrange
            return new CreateDoctorDto
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
