using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using relax_app.Extensions;
using static relax_app.Constants.ApiConfig;

namespace relax_app.App_Start
{
    public static class RouteConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.UseCentralRoutePrefix(new RouteAttribute($"api/{ApiVersion}"));
            });
        }
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseHttpsRedirection();
            app.UseRouting();
        }
    }
}
