namespace MedHub.Domain.Models
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string CNP { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public Person(string cNP, string firstName, string lastName, string email)
        {
            Id = Guid.NewGuid();
            CNP = cNP;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
