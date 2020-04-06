using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using LevelUpAPI.DataAccess;
using LevelUpAPI.DataAccess.Repositories;
using LevelUpAPI.DataAccess.Repositories.Interfaces;
using LevelUpAPI.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LevelUpAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string LevelUpSpecificOrigins = "_LevelUpSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            });

            //services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(LevelUpSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins()
                           .AllowAnyOrigin()
                           .AllowAnyHeader();
                });
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "api1";
                });

            services.AddDbContext<levelupContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(AutomapperProfile));
            services.AddTransient<IAvatarRepository, AvatarRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFoodEntryRepository, FoodEntryRepository>();
            services.AddTransient<IPasswordRecoveryDataRepository, PasswordRecoveryDataRepository>();

            services.AddTransient<IOFFDataRepository, OFFDataRepository>();
            services.AddTransient<IOFFCategoryRepository, OFFCategoryRepository>();
            services.AddTransient<IOFFDatasCategoryRepository, OFFDatasCategoryRepository>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0",
                    new OpenApiInfo {
                        Title = "LevelUpAPI",
                        Version = "v0",
                        Description = "LevelUP application Web API",
                        /*Contact = new OpenApiContact
                        {
                            Name = "LevelUP Team",
                            Email = "???",
                            Url = new Uri("???"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = new Uri("https://example.com/license"),
                        }*/
                    });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v0/swagger.json", "LevelUpAPI Doc V0");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
               
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(LevelUpSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
