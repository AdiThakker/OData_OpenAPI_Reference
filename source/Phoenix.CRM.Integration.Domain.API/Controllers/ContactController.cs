using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Phoenix.CRM.Integration.Entities;
using System.Linq;
using static Microsoft.AspNet.OData.Query.AllowedQueryOptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Phoenix.CRM.Integration.Domain.API.Controllers
{
    [ApiVersion("1.0")]
    [ODataRoutePrefix("Contact")]
    public class ContactController : ODataController
    {
        [ODataRoute("({key})")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Contact), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = Select)]
        public SingleResult<Contact> Get(int key) => SingleResult.Create(new[]
        {
            new Contact() { Id = key, FirstName = "John", LastName = "Doe", Address = "OData" }
        }.AsQueryable());

        [ODataRoute]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Contact), Status201Created)]
        [ProducesResponseType(Status400BadRequest)]
        public IActionResult Post([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            contact.Id = 100;

            return Created(contact);
        }
    }
}
