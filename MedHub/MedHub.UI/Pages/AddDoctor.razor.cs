using MedHub.UI.Pages.Services;
using Microsoft.AspNetCore.Components;
using MedHub.Shared.Domain;
using MedHub.UI.Pages.Services;
using Microsoft.AspNetCore.Components;
using DoctorCreateModel = MedHub.UI.Pages.Models.Doctor;
using System.Reflection.Metadata;

namespace MedHub.UI.Pages
{
    public partial class AddDoctor: ComponentBase
    {
        [Inject]
        public IDataService<Doctor> DoctorDataService { get; set; }
        public List<Doctor> Doctors { get; set; } = default!;
        protected async override Task OnInitializedAsync()
        {
            Doctors = (await DoctorDataService.GetAll()).ToList();
        }

        public void submitData()
        {
            /*string fname = document.getElementById("fname").value;*/
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
