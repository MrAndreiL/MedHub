using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace MedHub.Infrastructure.Repositories
{
    public class DoctorRepository : Repository<Doctor>
    {
        public DoctorRepository(MedHubContext context) : base(context)
        { }

        public override IEnumerable<Doctor> GetAll()
        {
            return context.Doctors.Include(d=>d.Specializations).ToList();
        }
    }
}
