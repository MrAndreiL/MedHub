using MedHub.API.Controllers;
using MedHub.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.IntegrationTests
{
    public class BaseIntegationTests
    {
        protected HttpClient HttpClient { get; private set; }

        public BaseIntegationTests()
        {
            var application = new WebApplicationFactory<PatientsController>().WithWebHostBuilder(builder => { });

            HttpClient = application.CreateClient();
            CleanDataBase();

        }
        private void CleanDataBase()
        {
            var databaseContext = new MedHubContext();
           // databaseContext.Patients.RemoveRange(databaseContext.Patients);
           // databaseContext.MedicalRecords.RemoveRange(databaseContext.MedicalRecords);
            databaseContext.SaveChanges();
        }
    }
}
