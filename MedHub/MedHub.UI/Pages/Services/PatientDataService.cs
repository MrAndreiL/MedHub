using MedHub.Shared.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using PatientCreateModel = MedHub.UI.Pages.Models.Patient;

namespace MedHub.UI.Pages.Services
{
    public class PatientDataService : IDataService<Patient>
    {
        private readonly HttpClient httpClient;
        public PatientDataService(HttpClient httpClient)
        {
           this.httpClient = httpClient;
        }

        public async void Create(Patient patient)
        {
            var client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(patient);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync("https://localhost:7058/v1/api/Patients", byteContent).Result;
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Patient>>
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
