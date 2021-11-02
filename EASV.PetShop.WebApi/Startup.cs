using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Services;
using EASV.PetShop.Security.Authentication;
using EASV.PetShop.Security.Authorization;
using EASV.PetShop.Security.Data;
using EASV.PetShop.SQL;
using EASV.PetShop.SQL.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OwnerRepository = EASV.PetShop.SQL.Repositories.OwnerRepository;
using PetRepository = EASV.PetShop.SQL.Repositories.PetRepository;

namespace EASV.PetShop.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        
        private IWebHostEnvironment Environment { get; }

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

            Byte[] secretBytes = new byte[40];

            using (var rngCsp = new System.Security.Cryptography.RNGCryptoServiceProvider() {})
            {
                rngCsp.GetBytes(secretBytes);
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(10)
                };
            });
            
            services.AddDbContext<SecurityContext>(opt =>
            {
                opt.UseLoggerFactory(loggerFactory)
                    .UseSqlite("Data Source=Security.db");
            }, ServiceLifetime.Transient);
            
            services.AddTransient<ISecurityContextInitializer, SecurityMemoryInitializer>();
            services.AddScoped<UserRepository>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("OwnerPolicy",
                    policy => { policy.Requirements.Add(new ResourceOwnerRequirement()); });
            });
            services.AddSingleton<IAuthorizationHandler, UserResourceOwnerAuthorizationService>();

            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));
            services.AddScoped<IUserAuthenticator, UserAuthenticator>();

            services.AddCors(options =>
            {
                options.AddPolicy("petshop-cors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
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
                    var services = scope.ServiceProvider;
                    var ctx = services.GetService<PetShopDBContext>();
                    var securityCtx = services.GetService<SecurityContext>();
                    var dbSecurityInit = services.GetService<ISecurityContextInitializer>();
                    dbSecurityInit.Initialize(securityCtx);
                    
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("petshop-cors");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}