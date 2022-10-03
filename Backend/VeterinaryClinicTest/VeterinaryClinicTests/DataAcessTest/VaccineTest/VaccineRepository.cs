using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using System.Timers;
using AutoMapper;
using Shouldly;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.DataAccess;
using VeterinaryClinicTest.DataAccess.Implementation.Repositories;
using VeterinaryClinicTests.DataAcessTest.Common;
using Xunit;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinicTest.Core.Exceptions;

namespace VeterinaryClinicTests.DataAcessTest.Vaccine
{
    public class VaccinRepository
    {
        private readonly ClinicDBContext Context;
        public VaccinRepository()
        {
            Context = VaccineContexFactory.Create();
        }
        [Fact]
        public async Task GetVaccinesList_Success()
        {
            // Arrange
            var repository = new VaccineRepository(Context);

            // Act
            var result = await repository.GetListAsync();

            // Assert
            result.Count.ShouldBe(10);
        }
        [Fact]
        public async Task Create_VaccineIsValid_ShouldCreateNewVaccine()
        {
            // Arrange
            var fixture = new Fixture();
            var vaccine = fixture.Create<VeterinaryClinicTest.DataAccess.Models.Vaccine>();
            var repository = new VaccineRepository(Context);

            // Act
            var result = await repository.AddAsync(vaccine);
            await repository.SaveChangesAsync(CancellationToken.None);

            // Assert
            result.ShouldBeAssignableTo<int>();
        }

        [Fact]
        public async Task Get_VaccinesByCount_Success()
        {
            // Arrange
            var repository = new VaccineRepository(Context);

            // Act
            var result = await repository.GetByCount();

            // Assert
            result.Count.ShouldBe(9);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(40)]
        [InlineData(50)]
        [InlineData(60)]
        [InlineData(70)]
        public async Task Get_VaccineById_Success(int id)
        {
            // Arrange
            var repository = new VaccineRepository(Context);

            // Act
            var result = await repository.GetAndEnsureExistAsync(id);

            // Assert
            result.ShouldNotBeNull();
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public async Task Get_VaccineById_ShouldThrowClinicException(int id)
        {
            // Arrange
            var repository = new VaccineRepository(Context);

            // Act
            var exception = await Assert.ThrowsAsync<ClinicExceptions>(() => repository.GetAndEnsureExistAsync(id));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldBe(ErrorCode.VaccineNotFound.Message);
        }

        [Fact]
        public async Task Get_VaccinesByTitle_ShouldNotBeEmpty()
        {

            // Arrange
            var repository = new VaccineRepository(Context);
            var fixture = new Fixture();
            var vaccine = fixture.Build<VeterinaryClinicTest.DataAccess.Models.Vaccine>()
                          .With(z => z.Title, "test")
                          .With(z => z.Id, 101)
                          .With(z=>z.IsDeleted,false)
                          .Create();

            // Act
            var vac = await repository.AddAsync(vaccine);
            await repository.SaveChangesAsync(CancellationToken.None);
            var result = await repository.GetByTitleAndEnsureExistAsync(vaccine.Title);

            // Assert
            result.ShouldNotBeEmpty();
        }

    }
}

