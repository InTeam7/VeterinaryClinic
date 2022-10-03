using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VeterinaryClinicTest.BusinessLogic.Commands.ClinicService.Models;
using VeterinaryClinicTest.BusinessLogic.Queries.ClinicService.Models;
using VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VeterinaryClinicTest.Controllers
{
    [Route("api/[controller]")]
    public class ClinicServiceController : BaseController
    {
        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll()
           => Ok(await Mediator.Send(new GetClinicServicesQueryModel()));

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
            => Ok(await Mediator.Send(new GetClinicServiceByIdQueryModel(id)));

    
        [HttpGet("title")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTitle(string title)
            => Ok(await Mediator.Send(new GetClinicServicesByTitleQueryModel(title)));

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateClinicService([FromBody] AddClinicServiceCommandModel model)
            => Ok(await Mediator.Send(model));

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateService([FromRoute] int id, [FromBody] UpdateClinicServiceCommandModel model)
        {
            await Mediator.Send(model.SetId(id));
            return Accepted();
        }

       
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
            => Accepted(await Mediator.Send(new DeleteClinicServiceCommandModel(id)));
    }
}

