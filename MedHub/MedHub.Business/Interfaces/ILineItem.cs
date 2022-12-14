using MedHub.Domain.Models;

namespace MedHub.Domain.Interfaces
{
    public interface ILineItem
    {

        public Guid Id { get; }
        public Drug Drug { get; }
        public int Quantity { get; }
    }
}
