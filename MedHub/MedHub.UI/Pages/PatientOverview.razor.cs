using MedHub.Shared.Domain;
using MedHub.UI.Pages.Services;
using Microsoft.AspNetCore.Components;

namespace MedHub.UI.Pages
{
    public partial class PatientOverview: ComponentBase
    {
        [Inject]
        public IDataService<Patient> PatientDataService { get; set; }

        public List<Patient> Patients { get; set; } = default!;
        protected async override Task OnInitializedAsync()
        {
            Patients =( await PatientDataService.GetAll()).ToList() ;
        }


    }
}
