using MedHub.Shared.Domain;
using MedHub.UI.Pages.Services;
using Microsoft.AspNetCore.Components;

namespace MedHub.UI.Pages
{
    public partial class DoctorOverview: ComponentBase
    {
        [Inject]
        public IDataService<Doctor> DoctorDataService { get; set; }
        public IDataService<Cabinet> CabinetDataService { get; set; }
        public List<Doctor> Doctors { get; set; } = default!;
        public List<Cabinet> Cabinets { get; set; } = default!;
        protected async override Task OnInitializedAsync()
        {
            Doctors = (await DoctorDataService.GetAll()).ToList();
            Cabinets= (await CabinetDataService.GetAll()).ToList();

        }
        protected async Task OnPostEdit(Guid id)
        {

        }

    }
}
