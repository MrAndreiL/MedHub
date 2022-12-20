using MedHub.Core.Entities;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;

namespace MedHub.Infrastructure.Repositories
{
    public class DoctorRepository : Repository<Doctor>
    {
        public DoctorRepository(MedHubContext context) : base(context)
        { }

        /*
        public override IEnumerable<Doctor> GetAll()
        {
            return context.Doctors.Include(d=>d.Specializations).ToList();
        }
        */
    }
}
