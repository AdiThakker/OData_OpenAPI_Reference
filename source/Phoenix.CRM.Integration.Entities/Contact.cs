using Microsoft.AspNet.OData.Query;

namespace Phoenix.CRM.Integration.Entities
{
    [Select]

    public class Contact
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

    }
}
