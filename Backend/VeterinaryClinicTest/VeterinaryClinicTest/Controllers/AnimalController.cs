using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VeterinaryClinicTest.Bus;
using VeterinaryClinicTest.BusinessLogic.Commands.Animal.Models;
using VeterinaryClinicTest.BusinessLogic.Commands.Client.Models;
using VeterinaryClinicTest.BusinessLogic.Commands.Vaccine.Models;
using VeterinaryClinicTest.BusinessLogic.Queries.Animals.Models;
using VeterinaryClinicTest.BusinessLogic.Queries.Client.Models;
using VeterinaryClinicTest.BusinessLogic.Queries.Vaccine.Models;
using VeterinaryClinicTest.Core.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VeterinaryClinicTest.Controllers
{
    [Route("api/[controller]")]
    public class AnimalController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        public AnimalController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll()
             => Ok(await Mediator.Send(new GetAnimalsQueryModel()));


        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
            => Ok(await Mediator.Send(new GetAnimalByIdQueryModel(id)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAnimal([FromBody] AddAnimalCommandModel model)
             => Ok(await Mediator.Send(model));

        [HttpGet("name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByName(string name)
             => Ok(await Mediator.Send(new GetAnimalsByNameQueryModel(name)));

        [HttpPost("ByOwnerId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByName([FromBody] GetAnimalsByOwnerIdQueryModel model)
             => Ok(await Mediator.Send(model));

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAnimal([FromRoute] int id, [FromBody] UpdateAnimalCommandModel model)
        {
            await Mediator.Send(model.SetId(id));
            return Accepted();
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName.GetUniqueFileName();
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.jpeg");
            }
        }
    }
        
}

