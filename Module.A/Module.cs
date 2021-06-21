using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Module.A.Api.Controllers;
using Module.A.Application;
using Module.A.Infrastructure;
using Module.Common;

namespace Module.A
{
    public class Module : IAddServices, IConfigureApplication
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ModuleAContext>(options =>
            {
                options.UseSqlServer("ModuleADatabase", x => x.MigrationsHistoryTable("__ModuleAMigrationHistory"));
            });
            services.AddApplication();

            services.AddTransient<AController>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
        }
    }
}