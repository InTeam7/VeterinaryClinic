using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeterinaryClinicTest.DataAccess.Enums;
using VeterinaryClinicTest.DataAccess.Models;


namespace VeterinaryClinicTest.DataAccess.EntityTypeConfigurations
{
    public class AnimalConfigurations : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Specie)
                .IsRequired()
                .HasConversion(x => x.ToString(), // to converter
                x => (Specie)Enum.Parse(typeof(Specie), x));// from converter;

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasConversion(x => x.ToString(), // to converter
                x => (Gender)Enum.Parse(typeof(Gender), x));// from converter;

            builder.HasMany(z => z.ProvidedServices)
                .WithOne(z => z.Animal)
                .HasForeignKey(z => z.AnimalId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            

            builder.HasOne(z => z.Owner)
                .WithMany(z => z.Animals)
                .HasForeignKey(z=>z.OwnerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();



        }
    }
}

