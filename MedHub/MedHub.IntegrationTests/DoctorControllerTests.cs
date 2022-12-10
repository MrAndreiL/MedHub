<<<<<<< HEAD
﻿using FluentAssertions;
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

=======
﻿using MedHub.API.DTOs;
using FluentAssertions;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http.HttpResults;

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
        [Fact]
        public async void WhenChangingDoctorCabinet_ThenCabinetShouldBeUpdated()
        {
            //Arrange
            var doctorDto= CreateSUT();
            var cabinetDto = new CreateCabinetDto() { Address = "Strada Carol nr 12" };
            var createDoctorResponse = await HttpClient.PostAsJsonAsync(ApiURL, doctorDto);
            var createCabinetResponse= await HttpClient.PostAsJsonAsync("v1/api/cabinets", cabinetDto);

            var doctor = createDoctorResponse.Content.ReadFromJsonAsync<DoctorDto>();
            var cabinet= createCabinetResponse.Content.ReadFromJsonAsync<CabinetDto>();
            //Act

            var updateDoctorCabinetResponse = await HttpClient.PostAsJsonAsync(
                $"{ApiURL}/{doctor.Id}/change-cabinet", cabinet);
            //Assert

            createCabinetResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            createDoctorResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            updateDoctorCabinetResponse.EnsureSuccessStatusCode();
            updateDoctorCabinetResponse.Content.Should().Be(System.Net.HttpStatusCode.OK);//idk if it should be smth else or ok


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
>>>>>>> 2aa811498f7d3498bf46cf9664d47e7dca614533
        public void Dispose()
        {
            CleanDatabases();
        }
    }
}
