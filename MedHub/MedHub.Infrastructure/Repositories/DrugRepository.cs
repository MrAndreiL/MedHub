using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MedHub.Infrastructure.Repositories
{
    public class DrugRepository : Repository<Drug>
    {
        public DrugRepository(MedHubContext context) : base(context)
        { }
    }
}
