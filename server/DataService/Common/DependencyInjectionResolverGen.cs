/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////
using DataService.BaseConnect;
using DataService.Models.Entities;
using Microsoft.Extensions.DependencyInjection;
using DataService.Repositories;
using DataService.Services;

namespace DataService.Commons
{
    public class DependencyInjectionResolverGen
    {
        public static void Initializer(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<BaseDbContext, RelaxAppContext>();
        
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        
            services.AddScoped<ISoundService, SoundService>();
            services.AddScoped<ISoundRepository, SoundRepository>();
        
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
