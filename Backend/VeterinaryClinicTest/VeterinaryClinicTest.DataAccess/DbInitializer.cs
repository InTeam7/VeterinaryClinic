using System;
namespace VeterinaryClinicTest.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(ClinicDBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}

