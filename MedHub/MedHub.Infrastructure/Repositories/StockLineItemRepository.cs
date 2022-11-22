using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MedHub.Infrastructure.Repositories
{
    public class StockLineItemRepository : Repository<StockLineItem>
    {
        public StockLineItemRepository(MedHubContext context) : base(context)
        { }
    }
}
