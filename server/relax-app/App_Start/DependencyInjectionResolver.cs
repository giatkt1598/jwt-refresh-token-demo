using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Handlers;

namespace relax_app.App_Start
{
    public class DependencyInjectionResolver
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            DataService.Commons.DependencyInjectionResolverGen.Initializer(services);
            services.AddDbContext<DataService.Models.Entities.RelaxAppContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

        }
    }
}
