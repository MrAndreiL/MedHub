using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MedHub.Infrastructure.Repositories
{
    public class MedicalRecordRepository : Repository<MedicalRecord>
    {
        public MedicalRecordRepository(MedHubContext context) : base(context)
        { }
    }
}
