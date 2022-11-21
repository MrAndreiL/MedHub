using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MedHub.Infrastructure.Repositories
{
    public class AllergenRepository : Repository<Allergen>
    {
        public AllergenRepository(MedHubContext context) : base(context)
        { }
    }
}
