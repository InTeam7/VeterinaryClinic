using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Handlers;
using VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Implementation.Queries;
using VeterinaryClinicTest.DataAccess;
using VeterinaryClinicTest.DataAccess.Implementation.Repositories;
using VeterinaryClinicTests.BusinessLogicTest.Common;
using Xunit;

namespace VeterinaryClinicTests.BusinessLogicTest.VaccineQueryTest
{
    [Collection("QueryCollection")]
    public class GetVaccineByIdQueryHandlerTest
    {
        private readonly ClinicDBContext Context;
        private readonly IMapper Mapper;
        private readonly VaccineRepository _repository;
        private readonly VaccineQueryService _service;

        public GetVaccineByIdQueryHandlerTest(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
            _repository = new VaccineRepository(Context);
            _service = new VaccineQueryService(_repository, Mapper);
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            // arrange
            var handler = new GetVaccineByIdQueryHandler(_service);
            var vaccineId = 10;
            // act
            var result = await handler.Handle(
                new GetVaccineByIdQueryModel(vaccineId), CancellationToken.None);
            // assert
            result.Should().BeOfType<VaccineDto>();
            result.Id.Should().Be(vaccineId);
        }
    }
}

