using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.Business.Models
{
    public class Invoice
    {
        public Guid Id { get;}
        public PacientModel Pacient { get; set; }
        public List<DrugModel> Drugs { get; set; }
        public double Price { get; set; }


    }
}
