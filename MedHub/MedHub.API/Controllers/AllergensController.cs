using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
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
            var allergen = new Allergen(allergenDto.Name);
            allergenRepository.Add(allergen);
            allergenRepository.SaveChanges();
            return Created(nameof(Get), allergen);
        }
    }
}
