using FluentAssertions;
using MedHub.API.DTOs;
using System.Net.Http.Json;

namespace MedHub.IntegrationTests
{
    public class DoctorControllerTests : BaseIntegrationTests, IDisposable
    {
        private const string ApiURL = "v1/api/doctors";


        [Fact]
        public async void When_CreateDoctor_Then_ShouldReturnDoctorInTheGetRequest()
        {
            // Arrange
            CreateDoctorDto doctorDto = CreateSUT();

            // Act
            var createDoctorResponse = await HttpClient.PostAsJsonAsync(ApiURL, doctorDto);
            var getDoctorResult = await HttpClient.GetAsync(ApiURL);

            // Assert
            createDoctorResponse.EnsureSuccessStatusCode();
            createDoctorResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            getDoctorResult.EnsureSuccessStatusCode();
            var doctors = await getDoctorResult.Content.ReadFromJsonAsync<List<DoctorDto>>();
            doctors.Count.Should().Be(1);
            doctors.Should().HaveCount(1);
            doctors.Should().NotBeNull();
        }

        private static CreateDoctorDto CreateSUT()
        {
            return new CreateDoctorDto
            {
                CNP = "1950430000000",
                FirstName = "Doctor",
                LastName = "Sex",
                Email = "haziflorinmarian@gmail.com",
            };
        }

        public void Dispose()
        {
            CleanDatabases();
        }
    }
}
