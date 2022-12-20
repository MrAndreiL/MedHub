using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class CabinetRepository : Repository<Cabinet>
    {
        public CabinetRepository(MedHubContext context) : base(context)
        { }
    }
}
