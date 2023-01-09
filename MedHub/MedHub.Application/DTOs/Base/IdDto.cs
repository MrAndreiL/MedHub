namespace MedHub.Application.DTOs.Base
{
    public class IdDto
    {
        public Guid Id { get; private set; }

        public IdDto(Guid id)
        {
            Id = id;
        }
    }
}
