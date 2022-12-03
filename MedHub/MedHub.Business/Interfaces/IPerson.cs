namespace MedHub.Domain.Interfaces
{
    public interface IPerson
    {
        public Guid Id { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
