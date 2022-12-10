using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.Shared.Domain
{
    public class MedicalSpeciality
    {
        public Guid Id { get; set; }
        public string SpecializationName { get; set; }
        public HashSet<Doctor> Doctors { get; set; }
    }
}
