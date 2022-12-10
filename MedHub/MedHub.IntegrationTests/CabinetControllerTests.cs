using MedHub.API.DTOs;
using FluentAssertions;
using System.Net.Http.Json;

namespace MedHub.IntegrationTests
{
    public class CabinetControllerTests : BaseIntegrationTests, IDisposable
    {

        private const string ApiURL = "v1/api/cabinets";

        [Fact]
        public async void WhenAddingDoctorsToCabinet_ThenCabinetDoctorsShouldBeUpdated()
        {
            // Arrange
            var doctorsDtos = new List<CreateDoctorDto>() {
                new CreateDoctorDto() { CNP="2881005398527", FirstName="Popescu", LastName="Ionescu", Email="popion@mail.com"},
                new CreateDoctorDto() { CNP="1970318354993", FirstName="Floarea", LastName="Andreea", Email="floareaandreea@gmail.com" },
            };
            var cabinetDto = CreateSUT();

            var createCabinetResponse = await HttpClient.PostAsJsonAsync(ApiURL, cabinetDto);
            var cabinet = createCabinetResponse.Content.ReadFromJsonAsync<DoctorDto>();

            // Act
            var registerDoctorsResponse = await HttpClient.PostAsJsonAsync
                ($"{ApiURL}/{cabinet.Id}/add-doctors", doctorsDtos);

            // Assert
            createCabinetResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            registerDoctorsResponse.EnsureSuccessStatusCode();
            registerDoctorsResponse.Content.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        private static CreateCabinetDto CreateSUT()
        {
            // Arrange
            return new CreateCabinetDto
            {
               Address="Strada Brazilor nr 680"
            };
        }

        public void Dispose()
        {
            CleanDatabases();
        }
    }
}
