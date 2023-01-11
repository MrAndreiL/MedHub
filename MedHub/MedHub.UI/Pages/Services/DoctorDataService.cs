using MedHub.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;
using DoctorCreateModel = MedHub.UI.Pages.Models.Doctor;
using System.Net.Http;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http.Headers;

namespace MedHub.UI.Pages.Services
{
    public class DoctorDataService : IDataService<Doctor>
    {
        private readonly HttpClient httpClient;

        public DoctorDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Doctor>>
                (await httpClient.GetStreamAsync("https://localhost:7058/v1/api/doctors"), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        public async void Create(Doctor doctor)
        {
            var client = new HttpClient();
            var myContent = JsonConvert.SerializeObject(doctor);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PostAsync("https://localhost:7058/v1/api/Doctors", byteContent).Result;
        }

        public Task<Doctor> GetDetails(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
