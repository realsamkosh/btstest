using bts.Models;
using bts.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonSerive _personService;

        public PersonController(IPersonSerive personService)
        {
            _personService = personService;
        }

        [HttpPost("Person")]
        public IActionResult Insert([FromBody] PersonDto model)
        {
            var addnew =  _personService.Insert(model);

            if (addnew.status == 1)
            {
                return Ok(addnew);
            }
            return BadRequest(addnew);
        }

        [HttpGet("Persons")]
        public IActionResult GetPersons()
        {
            var fetchdata = _personService.List();

                return Ok(fetchdata);

        }

        [HttpGet("Persons/{id}")]
        public IActionResult GetPerson([FromRoute] int id)
        {
            var fetchdata = _personService.GetById(id);
            return Ok(fetchdata);
        }
    }
}
