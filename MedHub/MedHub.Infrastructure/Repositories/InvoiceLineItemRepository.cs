using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MedHub.Infrastructure.Repositories
{
    public class InvoiceLineItemRepository : Repository<InvoiceLineItem>
    {
        public InvoiceLineItemRepository(MedHubContext context) : base(context)
        { }
    }
}
