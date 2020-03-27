﻿using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using Phoenix.CRM.Integration.Entities;

namespace Phoenix.CRM.Integration.Domain.API.Configuration
{
    public class ContactModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion) => builder.EntitySet<Contact>("Contact").EntityType.HasKey(o => o.FirstName);
    }
}
