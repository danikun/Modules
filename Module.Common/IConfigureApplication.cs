using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Module.Common
{
    public interface IConfigureApplication
    {
        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}