using System;
using MediatR;

namespace VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models
{
    public class UpdateVaccineCommandModel : IRequest
    {
        public int Id { get;protected set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Count { get; set; }

        public DateTime Date { get; set; }

        public DateTime ExpirationDate { get; set; }

        public UpdateVaccineCommandModel SetId(int id)
        {
            Id = id;
            return this;
        }



    }
}

