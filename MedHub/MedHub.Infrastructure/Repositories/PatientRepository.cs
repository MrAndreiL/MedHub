using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MedHub.Infrastructure.Repositories
{
    public class PatientRepository : Repository<Patient>
    {
        public PatientRepository(MedHubContext context) : base(context)
        { }
    }
}
