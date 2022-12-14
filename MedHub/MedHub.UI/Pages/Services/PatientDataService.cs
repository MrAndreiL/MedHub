using MedHub.Shared.Domain;
using System.Text.Json;

namespace MedHub.UI.Pages.Services
{
    public class PatientDataService : IDataService<Patient>
    {
        private readonly HttpClient httpClient;
        public PatientDataService(HttpClient httpClient)
        {
           this.httpClient = httpClient;
        }

        

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Patient>>
                (await httpClient.GetStreamAsync("https://localhost:7058/v1/api/patients"), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        public async Task<Patient> GetDetails(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
