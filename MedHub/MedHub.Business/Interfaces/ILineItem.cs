using MedHub.Domain.Models;

namespace MedHub.Domain.Interfaces
{
    public interface ILineItem
    {
        public Guid Id { get; set; }
        public Drug Drug { get; set; }
        public int Quantity { get; set; }
    }
}
