using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AppointmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /*
        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> Create([FromBody] CreateAppointmentCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{appointmentId:Guid}")]
        public async Task<ActionResult<AppointmentDto>> GetById(Guid appointmentId)
        {
            throw new NotImplementedException();
        }
        */
    }
}
