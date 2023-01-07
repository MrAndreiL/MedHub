﻿using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries
{
    public class GetAllCabinetsQuery : IRequest<Response<List<CabinetDto>>>
    {
    }
}
