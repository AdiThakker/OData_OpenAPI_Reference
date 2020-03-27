using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Phoenix.CRM.Integration.Entities;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Phoenix.CRM.Integration.Domain.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ODataRoutePrefix("Contact")]
    [ApiController]

    public class ContactController : ODataController
    {
        // GET: api/Contact
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [ODataRoute("({key})")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Contact), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        //[EnableQuery(AllowedQueryOptions = Select)]
        public SingleResult<Contact> Get(string key) => SingleResult.Create(new[] { new Contact() { FirstName = key, LastName = "Something", Address = "Unkown", City = "New York City", State = "NY" } }.AsQueryable());


        //// GET: api/Contact/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Contact
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Contact/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
