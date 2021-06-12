using BulkSenderAPI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;

namespace dijitalu.WebApi.Infrastructure
{
    public static class SwaggerRegisterExtension
    {
        public static IServiceCollection RegisterSwagger(this IServiceCollection serviceCollection)
        {
            // Register the Swagger generator, defining one or more Swagger documents
            serviceCollection.AddSwaggerGen(p =>
            {

                p.SwaggerDoc("v1", new OpenApiInfo { Title = "Xend Pay Invoicing Api", Version = "v1" });
                p.UseInlineDefinitionsForEnums();
                Dictionary<string, IEnumerable<string>> security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                OpenApiSecurityScheme openApiSecurityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,

                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                };

                OpenApiSecurityRequirement openAPiSecurityRequirement = new OpenApiSecurityRequirement();
                openAPiSecurityRequirement.Add(openApiSecurityScheme, new string[] { });

                p.AddSecurityRequirement(openAPiSecurityRequirement);

                p.AddSecurityDefinition("Bearer", openApiSecurityScheme);

                p.AddSecurityRequirement(openAPiSecurityRequirement);


               

                p.EnableAnnotations();


                //xml generated file from swagger
                var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, "xml");
                p.IncludeXmlComments(xmlFile);
            });


            return serviceCollection;
        }
    }

}
