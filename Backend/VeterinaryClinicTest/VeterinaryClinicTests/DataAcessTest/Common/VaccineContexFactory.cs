using System;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicTest.DataAccess;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTests.DataAcessTest.Common
{
    public class VaccineContexFactory
    {
        public static ClinicDBContext Create()
        {
            var options = new DbContextOptionsBuilder<ClinicDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ClinicDBContext(options);
            context.Database.EnsureCreated();
            VeterinaryClinicTest.DataAccess.Models.Vaccine[] vaccines = new VeterinaryClinicTest.DataAccess.Models.Vaccine[10];
            var fixture = new Fixture();
            for (int i = 0; i < vaccines.Length; i++)
            {
                var vaccine = fixture.Build<VeterinaryClinicTest.DataAccess.Models.Vaccine>()
                    .With(z=>z.Id,(i+1)*10)
                    .With(z=>z.IsDeleted,false)
                    .With(z=>z.Count,i)
                    .Create();
                vaccines[i] = vaccine;
            }
            context.Vaccines.AddRange(vaccines);
            context.SaveChanges();
            return context;



        }
        public static void Destroy(ClinicDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}

