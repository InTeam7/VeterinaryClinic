using System;
namespace VeterinaryClinicTest.BusinessLogic.Dto
{
    public class VaccineDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }

        public string Description { get; set; }
    }
}

