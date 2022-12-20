namespace MedHub.Core.Entities
{
    public class Person
    {
        public Guid Id { get; protected set; }
        public string CNP { get; protected set; } = null!;
        public string FirstName { get; protected set; } = null!;
        public string LastName { get; protected set; } = null!;
        public string Email { get; protected set; } = null!;
        public string PhoneNumber { get; protected set; } = null!;
    }
}
