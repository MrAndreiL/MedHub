using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class DrugRepository : Repository<Drug>
    {
        public DrugRepository(MedHubContext context) : base(context)
        { }
    }
}
