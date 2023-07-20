using Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace pharmacy.Api
{
    public static class IocIInstaller
    { 
   public static IServiceCollection AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("GSAPI",
              builder =>
              {
                  builder.WithOrigins("*");
                  builder.WithHeaders("*");
                  builder.WithMethods("*");
              });
        });

        return services;
    }

    public static IServiceCollection AddJWT(this IServiceCollection services)
    {
        var sp = services.BuildServiceProvider();
        Configs configs = sp.GetService<IOptions<Configs>>().Value;
        var key = Encoding.UTF8.GetBytes(configs.TokenKey);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                
                ClockSkew = TimeSpan.FromMinutes(configs.TokenTimeout),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                //IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Pharmacy Api",
                Description = "Pharmacy App API - Version01",
                //TermsOfService = new Uri("http://Sina.Com/"),
                License = new OpenApiLicense
                {
                    Name = "Pharmacy",
                    //Url = new Uri("http://Sina.Com/"),
                }
            });

            var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Bearer",
                Name = "Authorization",
                In = ParameterLocation.Header,
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });

            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //c.IncludeXmlComments(xmlPath);
        });
        return services;
    }
}
}
