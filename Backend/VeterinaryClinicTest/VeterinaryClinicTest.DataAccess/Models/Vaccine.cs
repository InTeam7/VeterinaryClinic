using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeterinaryClinicTest.DataAccess.Models
{
    public class Vaccine:BaseEntity
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int Count { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}

