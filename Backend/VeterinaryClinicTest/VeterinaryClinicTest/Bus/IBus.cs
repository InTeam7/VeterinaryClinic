using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace VeterinaryClinicTest.Bus
{
    public interface IBus
    {
         Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}

