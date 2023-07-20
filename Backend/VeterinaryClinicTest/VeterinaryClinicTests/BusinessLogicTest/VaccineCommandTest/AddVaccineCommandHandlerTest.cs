using System;
using AutoFixture;
using System.Threading.Tasks;
using Moq;
using VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands;
using VeterinaryClinicTest.DataAccess.Abstractions.Repositories;
using Xunit;
using VeterinaryClinicTest.DataAccess.Models;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;
using System.Threading;
using FluentAssertions;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Handlers;

namespace VeterinaryClinicTests.BusinessLogicTest.VaccineCommandTest
{
    public class AddVaccineCommandHandlerTest
    {
        private readonly Mock<IVaccineRepository> _vaccineRespositoryMock;
        private readonly VaccineCommandsService _service;
        //1

        public AddVaccineCommandHandlerTest()
        {
            _vaccineRespositoryMock = new Mock<IVaccineRepository>();
            _service = new VaccineCommandsService(_vaccineRespositoryMock.Object);
        }

        [Fact]
        public async Task Add_VaccineIsValid_ShouldCreateNewVaccine()
        {
            // arrange
            var fixture = new Fixture();
            var handler = new AddVaccineCommandHandler(_service);
            var expectedVaccineId = fixture.Create<int>();

            var addVaccine = fixture.Create<AddVaccineCommandModel>();

            _vaccineRespositoryMock.Setup(x =>x.AddAsync(It.IsAny<Vaccine>()))
                .ReturnsAsync(expectedVaccineId);

            // act
            var result = await handler.Handle(addVaccine,CancellationToken.None);

            // assert
            result.Should().Be(expectedVaccineId);
            _vaccineRespositoryMock.Verify(x => x.AddAsync(It.IsAny<Vaccine>()), Times.Once);
        }
    }
}

