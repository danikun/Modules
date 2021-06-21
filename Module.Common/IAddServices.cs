using Microsoft.Extensions.DependencyInjection;

namespace Module.Common
{
    public interface IAddServices
    {
        void ConfigureServices(IServiceCollection services);
    }
}