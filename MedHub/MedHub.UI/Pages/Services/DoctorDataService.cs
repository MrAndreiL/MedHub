using MedHub.Shared.Domain;
using System.Net.Http.Json;
using System.Text.Json;

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
            return await JsonSerializer.DeserializeAsync<IEnumerable<Doctor>>
                (await httpClient.GetStreamAsync("https://localhost:7058/v1/api/doctors"), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        public Task<Doctor> GetDetails(Guid id)
        {
            throw new NotImplementedException();
        }
        public async void PostDoctorCabinet(Guid doctorId, Cabinet cabinet)
        {
            await httpClient.PostAsJsonAsync<Cabinet>($"https://localhost:7058/v1/api/doctors/{doctorId}/change-cabinet", cabinet, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            });
        }
    }
}
