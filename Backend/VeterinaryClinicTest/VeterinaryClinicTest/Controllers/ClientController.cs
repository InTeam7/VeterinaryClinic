using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using VeterinaryClinicTest.BusinessLogic.Commands.Client.Models;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Queries.Client.Models;
using VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VeterinaryClinicTest.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : BaseController
    {
        
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var clients = await Mediator.Send(new GetClientsQueryModel());
            return Ok(clients);
        }
           // => Ok(await Mediator.Send(new GetClientsQueryModel()));

        
        [HttpGet("searchString")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByPhoneNumber(string searchString)
            => Ok(await Mediator.Send(new GetClientByPhoneNumberOrNameQueryModel(searchString)));

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
           => Ok(await Mediator.Send(new GetClientByIdQueryModel(id)));

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateClient([FromBody] AddClientCommandModel model)
             => Ok(await Mediator.Send(model));

       
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateClient([FromRoute] int id, [FromBody]  UpdateClientCommandModel model)
        {
            await Mediator.Send(model.SetId(id));
            return Accepted();
        }
    }
}

