using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class MedicalRecordRepository : Repository<MedicalRecord>
    {
        public MedicalRecordRepository(MedHubContext context) : base(context)
        { }
    }
}
