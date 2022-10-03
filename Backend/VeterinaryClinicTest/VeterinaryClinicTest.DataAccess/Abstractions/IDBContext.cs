using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess
{
    public interface IDBContext
    {
        DbSet<Animal> Animals { get; set; }

        DbSet<Doctor> Doctors { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<ClinicService> ClinicServices { get; set; }

        DbSet<Vaccine> Vaccines { get; set; }

        DbSet<ProvidedService> ProvidedServices { get; set; }



        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        bool EnsureDatabaseCreated();
    }
}

