using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AgrotoolsMaps.Host.Constants;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string assemblyName, string version)
        {
            services.AddSwaggerGen(c =>
            {
                c.UseAllOfForInheritance();
                c.CustomSchemaIds(type => type.FullName);
                c.DescribeAllParametersInCamelCase();
                c.SwaggerDoc($"v{version}", new OpenApiInfo
                {
                    Title = HostConstants.ProjectDisplayName,
                    Version = version,
                    Description = "Documentação dos endpoints do Agrotools Maps",
                    Contact = new OpenApiContact { Email = "dev@agrotools.com.br", Name = "Time de desenvolvimento" },
                    TermsOfService = new Uri("https://opensource.org/licenses/MIT"),
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });

                var authenticationScheme = new OpenApiSecurityScheme
                {
                    Description = "Insira somente seu token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                };

                

                c.AddSecurityDefinition(authenticationScheme.Reference.Id,
                    authenticationScheme);


                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        authenticationScheme, new string[] { }
                    },
                    
                });

                var filePath = Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.xml");
                c.IncludeXmlComments(filePath);
            });

            return services;
        }
    }
}