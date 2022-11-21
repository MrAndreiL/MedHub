using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MedHub.Infrastructure.Repositories
{
    public class MedicalSpecialityRepository : Repository<MedicalSpeciality>
    {
        public MedicalSpecialityRepository(MedHubContext context) : base(context)
        { }
    }
}
