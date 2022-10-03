using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.DataAccess.EntityTypeConfigurations
{
    public class ProvidedServiceConfigurations : IEntityTypeConfiguration<ProvidedService>
    { 

        public void Configure(EntityTypeBuilder<ProvidedService> builder)
        {
            builder.HasKey(z => z.Id);
            builder.HasIndex(z => z.Id).IsUnique();
            builder.Property(z => z.Date).IsRequired();
            builder.Property(z => z.Anamnesis).HasMaxLength(2000);
            builder.Property(z => z.Diagnosis).HasMaxLength(2000);

            
            builder.HasOne(z => z.Animal)
                .WithMany(z => z.ProvidedServices)
                .HasForeignKey(z => z.AnimalId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(z => z.Service)
                .WithMany(z => z.ProvidedServices)
                .HasForeignKey(z => z.ServiceId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(z => z.Doctor)
                .WithMany(z => z.ProvidedServices)
                .HasForeignKey(z => z.DoctorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}

