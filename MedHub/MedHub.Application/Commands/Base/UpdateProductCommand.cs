﻿namespace MedHub.Application.Commands.Base
{
    public class UpdateProductCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
