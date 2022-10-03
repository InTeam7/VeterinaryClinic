using System;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Mappers;
using VeterinaryClinicTest.DataAccess;
using VeterinaryClinicTests.DataAcessTest.Common;
using Xunit;

namespace VeterinaryClinicTests.BusinessLogicTest.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ClinicDBContext Context;
        public IMapper Mapper;
        public QueryTestFixture()
        {
            Context = VaccineContexFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new VaccineProfile());
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            VaccineContexFactory.Destroy(Context);
        }
    }
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

