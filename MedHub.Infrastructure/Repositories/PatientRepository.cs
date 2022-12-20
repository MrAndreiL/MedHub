using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class PatientRepository : Repository<Patient>
    {
        public PatientRepository(MedHubContext context) : base(context)
        { }
    }
}
