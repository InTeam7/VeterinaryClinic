using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeterinaryClinicTest.DataAccess.Models;


namespace VeterinaryClinicTest.DataAccess.EntityTypeConfigurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Speciality).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Doctor()
                {
                    Id = -1,
                    Name = "Иван",
                    PhoneNumber = "+7 777 77 77",
                    Speciality = "Хирург"

                },
                new Doctor()
                {
                    Id = -2,
                    Name = "Петр",
                    PhoneNumber = "+7 777 77 87",
                    Speciality = "Диагност"
                }
            );
            

            builder.HasMany(z => z.ProvidedServices)
                .WithOne(z => z.Doctor)
                .HasForeignKey(z => z.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

