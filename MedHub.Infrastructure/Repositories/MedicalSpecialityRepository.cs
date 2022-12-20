using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class MedicalSpecialityRepository : Repository<MedicalSpeciality>
    {
        public MedicalSpecialityRepository(MedHubContext context) : base(context)
        { }
    }
}
