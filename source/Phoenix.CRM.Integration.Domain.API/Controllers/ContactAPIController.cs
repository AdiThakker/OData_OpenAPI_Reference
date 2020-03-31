using Microsoft.AspNetCore.Mvc;
using Phoenix.CRM.Integration.Entities;
using System.Collections.Generic;

namespace Phoenix.CRM.Integration.Domain.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{apiVersion}/ContactApi")]
    [ApiController]
    public class ContactAPIController : ControllerBase
    {
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Contact>), 200)]
        public IActionResult Get()
        {
            var contacts = new[]
            {
                new Contact() { Id = 100, FirstName = "John", LastName = "Doe", Address = "Open API" },
                new Contact() { Id = 200, FirstName = "Johnny", LastName = "Doodle", Address = "Open API" },
                new Contact() { Id = 300, FirstName = "Juniper", LastName = "Dumpty", Address = "Open API" }
            };
            return Ok(contacts);
        }

        // GET: api/ContactAPI/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(new Contact() { Id = id, FirstName = "John", LastName = "Doe", Address = "Open API" });
        }

        // POST: api/ContactAPI
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Contact), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Contact contact)
        {
            contact.Id = 100;
            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }
    }
}
