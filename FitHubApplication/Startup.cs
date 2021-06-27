using FitHubApplication.Extensions;
using FitHubApplication.Models;
using FitHubApplication.Models.Utilities;
using FitHubApplication.Repositories;
using FitHubApplication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace FitHubApplication
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

            JwtSettings jwtSettings = new JwtSettings();
            Configuration.GetSection("JwtBearer").Bind(jwtSettings);

            services.AddCors(options =>
            {
                string[] corsOrigins = Configuration["CorsOrigins"].Split(",");

                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins(corsOrigins)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FitHubAPI"
                });
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

               

                c.IncludeXmlComments(xmlPath);

            });



            services.AddDbContext<FitHubDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FitHubDbContext")));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<FitHubDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
            });

            services.AddSingleton<JwtSettings>(jwtSettings);

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IUserService, UserService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("v1/swagger.json", "FitHub Docs");
            });

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
