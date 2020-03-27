using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using Phoenix.CRM.Integration.Entities;

namespace Phoenix.CRM.Integration.Domain.API.Configuration
{
    public class OrderModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            var order = builder.EntitySet<Order>("Orders").EntityType.HasKey(o => o.Id);
        }
    }
}
