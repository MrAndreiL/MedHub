﻿namespace MedHub.Application.Commands.Base
{
    public class CreatePersonCommand
    {
        public string CNP { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}