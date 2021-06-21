using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Module.Common
{
    public static class ModuleExtensions
    {
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            foreach (var module in GetModules(configuration))
            {
                var types = GetModuleTypes<IAddServices>(module);

                foreach (var addServices in types.Select(type => Activator.CreateInstance(type) as IAddServices))
                {
                    addServices?.ConfigureServices(services);
                }
            }
        }

        public static void UseModules(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            foreach (var module in GetModules(configuration))
            {
                var types = GetModuleTypes<IConfigureApplication>(module);

                foreach (var addServices in types.Select(type => Activator.CreateInstance(type) as IConfigureApplication))
                {
                    addServices?.Configure(app, env);
                }
            }
        }

        private static IEnumerable<Type> GetModuleTypes<T>(string module)
        {
            var assembly = Assembly.Load(module);
            var types = assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.IsAssignableTo(typeof(T)))
                .ToList();
            
            return types;
        }

        private static IEnumerable<string> GetModules(IConfiguration configuration)
        {
            return configuration.Get<ModuleConfiguration>().Modules ?? Enumerable.Empty<string>();
        }
    }
}