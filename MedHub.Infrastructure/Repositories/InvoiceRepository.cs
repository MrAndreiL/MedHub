using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class InvoiceRepository : Repository<Invoice>
    {
        public InvoiceRepository(MedHubContext context) : base(context)
        { }
    }
}
