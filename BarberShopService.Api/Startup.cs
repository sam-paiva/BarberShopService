using BarberShopService.Api.Interfaces;
using BarberShopService.Api.Repository;
using BarberShopService.Api.UnityOfWork;
using BarberShopService.Data;
using BarberShopService.IdentityService.Configuration;
using BarberShopService.Models.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace BarberShopService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddTransient<IUnityOfWork, UnityOfWorkClass>();
            services.AddScoped<IGenericRepository<Barber>, GenericRepository<Barber>>();
            services.AddScoped<IGenericRepository<BarberShop>, GenericRepository<BarberShop>>();
            services.AddDbContext<BarberShopContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
