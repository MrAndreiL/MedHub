using MedHub.API.DTOs;
using MedHub.Domain.Models;
using MedHub.Infrastructure.Repositories.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {
        private readonly IRepository<Drug> drugRepository;

        public DrugsController(IRepository<Drug> drugRepository)
        {
            this.drugRepository = drugRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(drugRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDrugDto drugDto)
        {
            var drug = Drug.Create(drugDto.Name, drugDto.Description, drugDto.Price);

            if (drug.IsSuccess)
            {
                drugRepository.Add(drug.Entity);

                var fullDrug = new DrugDto
                {
                    Id = drug.Entity.Id,
                    Name = drug.Entity.Name,
                    Description = drug.Entity.Description,
                    Price = drug.Entity.Price
                };

                return Created(nameof(Get), fullDrug);
            }

            return BadRequest(drug.Error);
        }
    }
}
