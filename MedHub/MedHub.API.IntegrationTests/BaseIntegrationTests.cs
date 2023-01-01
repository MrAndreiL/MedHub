using MedHub.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MedHub.API.IntegrationTests
{
    public class BaseIntegrationTests<TController> where TController : class
    {
        protected HttpClient Client { get; private set; }
        private MedHubContext context;

        private const int apiVersion = 1;
        protected string baseApiURL => $"api/v{apiVersion}";

        protected BaseIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<MedHubContext>()
                .UseSqlite("Data Source = MedHubTests.db")
                .Options;
            var application = new WebApplicationFactory<TController>().WithWebHostBuilder(builder => {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton(options);
                    services.AddScoped<MedHubContext>();
                });
            });
            Client = application.CreateClient();
            context = new MedHubContext(options);
            context.Database.Migrate();
            CleanDatabase();
        }

        protected void CleanDatabase()
        {
            context.Allergens.RemoveRange(context.Allergens.ToList());
            context.SaveChanges();
        }
    }
}

/*
Source: 
https://blog.markvincze.com/overriding-configuration-in-asp-net-core-integration-tests/
https://www.fearofoblivion.com/asp-net-core-integration-testing
*/
