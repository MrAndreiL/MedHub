using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class ServiceRepository : Repository<Service>
    {
        public ServiceRepository(MedHubContext context) : base(context)
        { }
    }
}
