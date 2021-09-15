using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.DataAccess;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Services;
using EASV.PetShop.SQL;
using EASV.PetShop.SQL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace EASV.PetShop.WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "EASV.PetShop.WebApi", Version = "v1"});
            });
            
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IInsuranceService, InsuranceService>();
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            
            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddConsole();
                }
            );
            
            services.AddDbContext<PetShopDBContext>(
                opt =>
                {
                    opt
                        .UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=PetShopApp.db");
                }, ServiceLifetime.Transient);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EASV.PetShop.WebApi v1"));
                
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopDBContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}