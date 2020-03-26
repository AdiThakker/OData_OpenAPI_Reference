using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Phoenix.CRM.Integration.Domain.API.Swagger
{
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) return;

            var apiDescription = context.ApiDescription;
            operation.Deprecated |= apiDescription.IsDeprecated();

            // REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/412
            // REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/pull/413
            foreach (var parameter in operation.Parameters)
            {
                var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                if (parameter.Description == null) parameter.Description = description.ModelMetadata?.Description;

                if (parameter.Schema.Default == null && description.DefaultValue != null) parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());


                parameter.Required |= description.IsRequired;
            }
        }
    }
}
