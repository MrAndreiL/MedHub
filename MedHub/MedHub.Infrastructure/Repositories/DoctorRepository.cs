using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MedHub.Infrastructure.Repositories
{
    public class DoctorRepository : Repository<Doctor>
    {
        public DoctorRepository(MedHubContext context) : base(context)
        { }
    }
}
