namespace MedHub.Domain.Models
{
    public class Person
    {
        //public string CNP { get; private set; }
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        public Person(string firstName, string lastName, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
