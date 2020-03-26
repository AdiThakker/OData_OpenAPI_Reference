using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Phoenix.CRM.Integration.Domain.API.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public IApiVersionDescriptionProvider Provider { get; }

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => Provider = provider ?? throw new System.ArgumentNullException(nameof(provider));

        public void Configure(SwaggerGenOptions options)
        {
            Provider.ApiVersionDescriptions.ToList().ForEach(description => options.SwaggerDoc(description.GroupName, new OpenApiInfo()
            {
                Title = "Sample API",
                Version = description.ApiVersion.ToString(),
                Description = description.IsDeprecated ? "This API version has been deprecated" : "A sample application with Swagger, Swashbuckle, and API versioning.",
                Contact = new OpenApiContact() { Name = "Contact Name", Email = "Some email address" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            }));
        }
    }
}
