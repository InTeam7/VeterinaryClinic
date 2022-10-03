using System;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Models
{
    public class GetClinicServiceByIdQueryModel : IRequest<ClinicServiceDto>
    {
        public int Id { get; set; }
        public GetClinicServiceByIdQueryModel(int id)
        {
            Id = id;
        }
    }
}

