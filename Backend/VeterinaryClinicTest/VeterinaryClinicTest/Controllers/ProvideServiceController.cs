using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VeterinaryClinicTest.BusinessLogic.Commands.ProvidedService.Models;
using VeterinaryClinicTest.BusinessLogic.Queries.ProvidedService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VeterinaryClinicTest.Controllers
{
    [Route("api/[controller]")]
    public class ProvideServiceController : BaseController
    {
        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll()
            => Ok(await Mediator.Send(new GetProvidedServicesQueryModel()));

        
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
            => Ok(await Mediator.Send(new GetProvidedServiceByIdQueryModel(id)));

       
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddService([FromBody] AddProvidedServiceCommandModel model)
            => Ok(await Mediator.Send(model));

        [HttpGet("name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByDoctorName(string name)
            => Ok(await Mediator.Send(new GetProvidedServicesByDoctorNameQueryModel(name)));

        [HttpGet("docId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByDoctorId(int id)
            => Ok(await Mediator.Send(new GetProvidedServicesByDoctorIdQueryModel(id)));


    }
}

