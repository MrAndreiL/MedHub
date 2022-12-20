using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class AppointmentRepository : Repository<Appointment>
    {
        public AppointmentRepository(MedHubContext context) : base(context)
        { }
    }
}
