using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class InvoiceItemRepository : Repository<InvoiceItem>
    {
        public InvoiceItemRepository(MedHubContext context) : base(context)
        { }
    }
}
