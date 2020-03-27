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
    [ODataRoutePrefix("Orders")]
    public class OrdersController : ODataController
    {
        [ODataRoute("({key})")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Order), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [EnableQuery(AllowedQueryOptions = Select)]
        public SingleResult<Order> Get(int key) => SingleResult.Create(new[] { new Order() { Id = key } }.AsQueryable());
    }
}