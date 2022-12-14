using MedHub.Shared.Domain;
using MedHub.UI;
using MedHub.UI.Pages.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddHttpClient<IDataService<Patient>, PatientDataService>(
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    );
builder.Services.AddHttpClient<IDataService<Doctor>, DoctorDataService>(
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    );
builder.Services.AddHttpClient<IDataService<Cabinet>, CabinetDataService>(
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    );
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
