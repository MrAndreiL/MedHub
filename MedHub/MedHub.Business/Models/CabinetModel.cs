using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.Business.Models
{
    public class CabinetModel
    {
        public Guid Id { get; }
        public string Address { get; set; }

        public List<DrugModel> Drugs { get; set; }
    }
}
