using System;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Handlers;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands;
using VeterinaryClinicTest.DataAccess.Implementation.Repositories;
using VeterinaryClinicTests.BusinessLogicTest.Common;
using Xunit;

namespace VeterinaryClinicTests.BusinessLogicTest.VaccineCommandTest
{
    public class DeleteVaccineCommandHandlerTest : TestCommandBase
    {
        private readonly VaccineCommandsService _service;
        private readonly VaccineRepository _repository;

        public DeleteVaccineCommandHandlerTest()
        {
            _repository = new VaccineRepository(Context);
            _service = new VaccineCommandsService(_repository);
        }

        [Fact]
        public async Task Delete_Vaccine_Success()
        {
            // arrange
            var handler = new DeleteVaccineCommandHandler(_service);
            var vaccineIdForUpdate = 10;
            var deleteVaccineModel = new DeleteVaccineCommandModel(vaccineIdForUpdate);
       
            // act
            await handler.Handle(deleteVaccineModel, CancellationToken.None);
            var vaccine = await _repository.GetAndEnsureExistAsync(vaccineIdForUpdate);

            // assert
            vaccine.IsDeleted.Should().Be(true);
        }
    }
}

