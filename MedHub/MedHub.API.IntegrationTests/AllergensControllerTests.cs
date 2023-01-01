using FluentAssertions;
using MedHub.API.Controllers;
using MedHub.Application.Commands;
using MedHub.Core.Entities;
using System.Net.Http.Json;

namespace MedHub.API.IntegrationTests
{
    public class AllergensControllerTests : BaseIntegrationTests<AllergensController>, IDisposable
    {
        private string allergenApiURL => $"{baseApiURL}/Allergens";

        [Fact]
        public async void When_CreatedAllergen_Then_ShouldReturnAllergenInGetRequest()
        {
            // Arrange
            var createAllergenCommand = CreateSUT();

            // Act
            var createAllergenResponse = await Client.PostAsJsonAsync(allergenApiURL, createAllergenCommand);
            var getAllergenResponse = await Client.GetAsync(allergenApiURL);

            // Assert
            createAllergenResponse.EnsureSuccessStatusCode();
            createAllergenResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            getAllergenResponse.EnsureSuccessStatusCode();
            var allergens = await getAllergenResponse.Content.ReadFromJsonAsync<List<Allergen>>();
            allergens.Should().HaveCount(1);
            allergens.Should().NotBeNull();
        }

        private static CreateAllergenCommand CreateSUT()
        {
            return new CreateAllergenCommand
            {
                Name = "Gluten"
            };
        }

        public void Dispose()
        {
            CleanDatabase();
            GC.SuppressFinalize(this);
        }
    }
}
