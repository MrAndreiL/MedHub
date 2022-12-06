namespace MedHub.Domain.Interfaces
{
    public interface IPerson
    {
        public Guid Id { get; }
        public string CNP { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
    }
}
