﻿using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.InvoiceQueries
{
    public class GetDrugByIdQuery : IdCommandQuery, IRequest<Response<DrugDto>>
    {
        public GetDrugByIdQuery(Guid id) : base(id) { }
    }
}