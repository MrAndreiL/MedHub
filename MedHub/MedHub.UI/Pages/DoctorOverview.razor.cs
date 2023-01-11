using MedHub.Shared.Domain;
using MedHub.UI.Pages.Services;
using Microsoft.AspNetCore.Components;
using DoctorCreateModel = MedHub.UI.Pages.Models.Doctor;


namespace MedHub.UI.Pages
{
    public partial class DoctorOverview: ComponentBase
    {
        [Inject]
        public IDataService<Doctor> DoctorDataService { get; set; }
        public List<Doctor> Doctors { get; set; } = default!;
        protected async override Task OnInitializedAsync()
        {
            Doctors = (await DoctorDataService.GetAll()).ToList();
        }

        private async void CreateDoctor()
        {
            Console.WriteLine("heeeloooooooooooooo");
            Doctor doctor = new Doctor()
            {
                CNP = "05123456789",
                FirstName = "Andrei",
                LastName = "Lungu",
                Email = "andreiLungu@sebastian.ro",

            };

            DoctorDataService.Create(doctor);
        }

        protected async Task OnPostEdit(Guid id)
        {
        }
    }
}
