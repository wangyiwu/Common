﻿using Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationServiceExtensions
    {
        public static IServiceCollection AddOptionValidation(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection Configure<T>(this IServiceCollection services, Action<IServiceProvider, T> configure) where T : class
        {
            services.AddSingleton<IConfigureOptions<T>>(c => new ConfigureOptions<T>(o => configure(c, o)));

            return services;
        }

        public static IServiceCollection Configure<T>(this IServiceCollection services, IConfiguration config, string path) where T : class
        {
            services.AddOptions<T>().Bind(config.GetSection(path));

            return services;
        }

        public static IServiceCollection ConfigureAndValidate<T>(this IServiceCollection services, IConfiguration config, string path) where T : class, IValidatableOptions
        {
            services.AddOptions<T>().Bind(config.GetSection(path));

            services.AddSingleton<IErrorProvider>(c => ActivatorUtilities.CreateInstance<OptionsErrorProvider<T>>(c, path));

            return services;
        }
    }
}
