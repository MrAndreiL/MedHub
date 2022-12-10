using MedHub.Domain.Models;

namespace MedHub.Domain.Interfaces
{
    public interface ILineItem
    {
<<<<<<< HEAD
        public Guid Id { get; set; }
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
=======
        public Guid Id { get; }
        public Drug Drug { get; }
        public int Quantity { get; }
>>>>>>> 2aa811498f7d3498bf46cf9664d47e7dca614533
    }
}
