using AutoMapper;
using MedHub.Application.Commands;
using MedHub.Application.Mappers;
using MedHub.Application.Queries;
using MedHub.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AllergensController : ControllerBase
    {
        private readonly IMediator mediator;

        public AllergensController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AllergenResponse>> Create([FromBody] CreateAllergenCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("{allergenId:Guid}")]
        public async Task<ActionResult<AllergenResponse>> GetById(Guid allergenId)
        {
            return Ok(await mediator.Send(new GetAllergenByIdQuery(allergenId)));
        }

        [HttpGet]
        public async Task<List<AllergenResponse>> GetAll()
        {
            return await mediator.Send(new GetAllAllergensQuery());
        }

        [HttpPut("{allergenId:Guid}")]
        public async Task<ActionResult<AllergenResponse>> Update([FromBody] CreateAllergenCommand command, Guid allergenId)
        {
            return Ok(await mediator.Send(new UpdateAllergenCommand(command, allergenId)));
        }

        [HttpDelete("{allergenId:Guid}")]
        public async Task<ActionResult<AllergenResponse>> Delete(Guid allergenId)
        {
            return Ok(await mediator.Send(new DeleteAllergenCommand(allergenId)));
        }
    }
}
