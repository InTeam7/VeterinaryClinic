using System;
using AutoFixture;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Handlers;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using VeterinaryClinicTest.DataAccess.Models;
using Xunit;
using FluentAssertions;
using VeterinaryClinicTests.BusinessLogicTest.Common;
using VeterinaryClinicTest.DataAccess.Implementation.Repositories;
using VeterinaryClinicTests.DataAcessTest.Common;

namespace VeterinaryClinicTests.BusinessLogicTest.VaccineCommandTest
{
    public class UpdateVaccineCommandHandlerTest:TestCommandBase 
    {
        private readonly VaccineCommandsService _service;
        private readonly VaccineRepository _repository;

        public UpdateVaccineCommandHandlerTest()
        {
            _repository = new VaccineRepository(Context);
            _service = new VaccineCommandsService(_repository);
        }

        [Fact]
        public async Task Update_Vaccine_Success()
        {
            // arrange
            var handler = new UpdateVaccineCommandHandler(_service);
            var updatedTitle = "new title";
            var vaccineIdForUpdate = 10;
            var upVaccineModel = new UpdateVaccineCommandModel()
            {
                Title = updatedTitle
            };
            upVaccineModel.SetId(vaccineIdForUpdate);

            // act
            await handler.Handle(upVaccineModel, CancellationToken.None);
            var vaccine = await _repository.GetAndEnsureExistAsync(vaccineIdForUpdate);

            // assert
            vaccine.Title.Should().Be(updatedTitle);
        }
    }
}

