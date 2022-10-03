using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Handlers;
using VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Services.Implementation.Commands;
using VeterinaryClinicTest.BusinessLogic.Services.Implementation.Queries;
using VeterinaryClinicTest.DataAccess;
using VeterinaryClinicTest.DataAccess.Implementation.Repositories;
using VeterinaryClinicTests.BusinessLogicTest.Common;
using Xunit;

namespace VeterinaryClinicTests.BusinessLogicTest.VaccineQueryTest
{
    [Collection("QueryCollection")]
    public class GetVaccinesQueryHandlerTest 
    {
        private readonly ClinicDBContext Context;
        private readonly IMapper Mapper;
        private readonly VaccineRepository _repository;
        private readonly VaccineQueryService _service;

        public GetVaccinesQueryHandlerTest(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
            _repository = new VaccineRepository(Context);
            _service = new VaccineQueryService(_repository,Mapper);
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            // arrange
            var handler = new GetVaccinesQueryHandler(_service);
            // act
            var result = await handler.Handle(
                new GetVaccinesQueryModel(),CancellationToken.None);
            // assert
            result.Should().NotBeNull().And.HaveCount(10);
        }
    }
}

