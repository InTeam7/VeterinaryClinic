using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeterinaryClinicTest.DataAccess.Models;


namespace VeterinaryClinicTest.DataAccess.EntityTypeConfigurations
{
    public class ClinicServiceConfiguration : IEntityTypeConfiguration<ClinicService>
    {
        public void Configure(EntityTypeBuilder<ClinicService> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(2000);

            
            builder.HasMany(z => z.ProvidedServices)
                .WithOne(z => z.Service)
                .HasForeignKey(z => z.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

