using Autofac;
using Common;
using Contracts;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using pharmacy.Api;
using pharmacy.Api.MiddleWares;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<Configs>(Configuration.GetSection("Configs"));

            #region Ioc Section
            services.AddCommon();
            services.AddApplicationService();
            services.AddRepositories();
            #endregion
            //ioc
            services.AddCustomCors();
            services.AddJWT();
            services.AddSwagger();
            services.AddControllers();
            services.AddStackExchangeRedisCache(options => { options.Configuration = Configuration.GetSection("Configs").GetSection("RedisConnection").Value; });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddServices();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pharmacy.Api v1"));
            }
            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("GSAPI");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"DataFile_Repository")),
                RequestPath = new PathString("/DataFile_Repository")
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
