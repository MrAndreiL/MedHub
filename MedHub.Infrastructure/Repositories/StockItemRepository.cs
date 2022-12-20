using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class StockItemRepository : Repository<StockItem>
    {
        public StockItemRepository(MedHubContext context) : base(context)
        { }
    }
}
