using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;

namespace MedHub.Infrastructure.Repositories
{
    public class InvoiceRepository : Repository<Invoice>
    {
        public InvoiceRepository(MedHubContext context) : base(context)
        { }
    }
}
