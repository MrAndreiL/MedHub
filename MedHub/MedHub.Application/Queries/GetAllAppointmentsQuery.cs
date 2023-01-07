using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedHub.Application.Queries
{
    public class GetAllAppointmentsQuery : IRequest<Response<List<AppointmentDto>>>
    {
    }
}
