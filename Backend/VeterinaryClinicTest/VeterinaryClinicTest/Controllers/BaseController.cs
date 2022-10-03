using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using VeterinaryClinicTest.Bus;

namespace VeterinaryClinicTest.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IBus _mediator;
        protected IBus Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IBus>();

        
    }
}

