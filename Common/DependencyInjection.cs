using Common.DBHelper;
using Common.Encryption;
using Common.FormatConvertor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.AddScoped<IConnectionUtility, ConnectionUtility>();
            services.AddScoped<ICustomEncryption, CustomEncryption>();
            services.AddSingleton<IUtility, Utility>();

            return services;
        }

    }
}
