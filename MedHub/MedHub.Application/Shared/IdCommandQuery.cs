namespace MedHub.Application.Shared
{
    public class IdCommandQuery
    {
        public Guid Id { get; private set; }

        public IdCommandQuery(Guid id)
        {
            Id = id;
        }
    }
}
