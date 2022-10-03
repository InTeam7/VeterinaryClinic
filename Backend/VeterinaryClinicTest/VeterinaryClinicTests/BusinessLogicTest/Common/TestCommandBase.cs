using System;
using VeterinaryClinicTest.DataAccess;
using VeterinaryClinicTests.DataAcessTest.Common;

namespace VeterinaryClinicTests.BusinessLogicTest.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ClinicDBContext Context;

        public TestCommandBase()
        {
            Context = VaccineContexFactory.Create();
        }

        public void Dispose()
        {
            VaccineContexFactory.Destroy(Context);
        }
    }
}

