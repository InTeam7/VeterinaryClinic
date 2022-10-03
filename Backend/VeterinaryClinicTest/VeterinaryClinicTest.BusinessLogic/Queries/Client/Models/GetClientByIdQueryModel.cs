using System;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Client.Models
{
    public class GetClientByIdQueryModel : IRequest<ClientDto>
    {
        public int Id { get; set; }
        public GetClientByIdQueryModel(int id)
        {
            Id = id;
        }
    }
}

