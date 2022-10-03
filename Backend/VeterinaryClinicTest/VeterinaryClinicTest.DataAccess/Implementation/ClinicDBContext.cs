using System;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicTest.DataAccess.Models;
using VeterinaryClinicTest.DataAccess.EntityTypeConfigurations;

namespace VeterinaryClinicTest.DataAccess
{
    public class ClinicDBContext : DbContext,IDBContext
    {
        public ClinicDBContext(DbContextOptions<ClinicDBContext> opt) :base(opt)
        {
            
        }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClinicService> ClinicServices { get; set; }

        public DbSet<Vaccine> Vaccines { get; set; }

        public DbSet<ProvidedService> ProvidedServices { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalConfigurations());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ClinicServiceConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new VaccineConfiguration());
            modelBuilder.ApplyConfiguration(new ProvidedServiceConfigurations());
            base.OnModelCreating(modelBuilder);
        }

        public bool EnsureDatabaseCreated()
            => Database.EnsureCreated();


    }
}

