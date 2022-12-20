using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(MedHubContext context) : base(context)
        { }
    }
}
