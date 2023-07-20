using Autofac;
using Contracts;
using Contracts.Interface.Base;
using Contracts.Interface.Security;
using Contracts.Interface.Shared;
using Contracts.Interface.SystemNav;
using FluentValidation.AspNetCore;
using Infrastructure.Repositories.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Service.Service.Base;
using Service.Service.Security;
using Service.Service.Shared;
using Service.Service.SystemNav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IDropDownService, DropDownService>();
            services.AddScoped<IMenuService, MenuService>();

            services.AddScoped<IUploadService, UploadFileService>();


            
            services.AddScoped<IAuthenticateService, AuthenticateService>();
           // services.AddScoped<IPermissionService, PermissionService>();
            services.AddSingleton(typeof(IRedisService<>), typeof(RedisService<>));
            services.AddControllers() // Could be AddController or AddMvc too
            .AddFluentValidation(opt => { opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()); });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    var c = new GSActionResult<ValidationResult>();
                    var v = new ValidationResult("Error", errors);
                    c.IsSuccess = false;
                    c.Data = v;
                    return new BadRequestObjectResult(c);
                };
            });
            return services;
        }

    }
    public static class AutoRegisterServices
    {
        public static void AddServices(this ContainerBuilder containerBuilder)
        {
            var baseServices = typeof(IBaseService).Assembly;
            containerBuilder.RegisterAssemblyTypes(baseServices)
                .AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


        }
    }
}
