using Microsoft.AspNet.OData.Query;

namespace Phoenix.CRM.Integration.Entities
{
    [Select]
    public class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        /// <value>The order's unique identifier.</value>
        public int Id { get; set; }
    }
}
