using MedHub.API.Controllers;
using MedHub.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace MedHub.IntegrationTests
{
    public class BaseIntegrationTests
    {
        private DbContextOptions<MedHubContext> options = new DbContextOptionsBuilder<MedHubContext>()
                .UseSqlite("Data Source = MyTests.db").Options;
        protected HttpClient HttpClient { get; private set; }

        private MedHubContext databaseContext;
        protected BaseIntegrationTests()
        {
            var patientsApplication = new WebApplicationFactory<PatientsController>()
                .WithWebHostBuilder(builder => { });
            HttpClient = patientsApplication.CreateClient();
            databaseContext = new MedHubContext(options);
        }
        protected void CleanDatabases()
        {
            databaseContext.Patients.RemoveRange(databaseContext.Patients.ToList());
            databaseContext.SaveChanges();
            databaseContext.Database.EnsureDeleted();
        }
    }
}
