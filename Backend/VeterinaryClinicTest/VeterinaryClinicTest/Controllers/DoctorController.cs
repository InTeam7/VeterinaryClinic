using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VeterinaryClinicTest.BusinessLogic.Commands.Client.Models;
using VeterinaryClinicTest.BusinessLogic.Commands.Doctor.Models;
using VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VeterinaryClinicTest.Controllers
{
    [Route("api/[controller]")]
    public class DoctorController : BaseController
    { 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll()
            => Ok(await Mediator.Send(new GetDoctorsQueryModel()));

        
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
            => Ok(await Mediator.Send(new GetDoctorByIdQueryModel(id)));

        
        [HttpGet("name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByName(string name)
            => Ok(await Mediator.Send(new GetDoctorsByNameQueryModel(name)));

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorCommandModel model)
        {
            await Mediator.Send(model.SetId(id));
            return Accepted();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddDoctor([FromBody] AddDoctorCommandModel model)
             => Ok(await Mediator.Send(model));

        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDoctor(int id)
            => Accepted(await Mediator.Send(new DeleteDoctorCommandModel(id)));
    }
}

