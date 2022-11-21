using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MedHub.Infrastructure.Repositories
{
    public class CabinetRepository : Repository<Cabinet>
    {
        public CabinetRepository(MedHubContext context) : base(context)
        { }
    }
}
