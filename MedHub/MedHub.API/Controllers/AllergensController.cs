using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AllergensController : ControllerBase
    {
        private readonly IRepository<Allergen> allergenRepository;

        public AllergensController(IRepository<Allergen> allergenRepository)
        {
            this.allergenRepository = allergenRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(allergenRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAllergenDto allergenDto)
        {
            var allergen = Allergen.Create(allergenDto.Name);

            if (allergen.IsSuccess)
            {
                allergenRepository.Add(allergen.Entity);
                allergenRepository.SaveChanges();

                var fullAllergen = new AllergenDto
                {
                    Id = allergen.Entity.Id,
                    Name = allergen.Entity.Name
                };

                return Created(nameof(Get), fullAllergen);
            }

            return BadRequest(allergen.Error);
        }
    }
}
