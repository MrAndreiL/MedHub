using MedHub.Shared.Domain;
using System.Text.Json;

namespace MedHub.UI.Pages.Services
{
    public class CabinetDataService: IDataService<Cabinet>
    {
        private readonly HttpClient httpClient;

        public CabinetDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Cabinet>> GetAll()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Cabinet>>
                (await httpClient.GetStreamAsync("https://localhost:7058/v1/api/cabinets"), new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        public Task<Cabinet> GetDetails(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
