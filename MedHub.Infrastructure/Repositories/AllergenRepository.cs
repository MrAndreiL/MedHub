using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class AllergenRepository : Repository<Allergen>
    {
        public AllergenRepository(MedHubContext context) : base(context)
        { }
    }
}
