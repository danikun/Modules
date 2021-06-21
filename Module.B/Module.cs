using System;
using Microsoft.Extensions.DependencyInjection;
using Module.B.Api;
using Module.Common;

namespace Module.B
{
    public class Module : IAddServices
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<BController>();
        }
    }
}