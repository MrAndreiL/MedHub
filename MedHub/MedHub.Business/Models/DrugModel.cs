using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.Business.Models
{
    public class DrugModel
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
        //Curency ?
        //Alergeni
    }
}
