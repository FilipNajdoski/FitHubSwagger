using FitHubApplication.Extensions;
using FitHubApplication.Helpers;
using FitHubApplication.Models;
using FitHubApplication.Models.Constants;
using FitHubApplication.Models.Entities;
using FitHubApplication.Models.Utilities;
using FitHubApplication.Repositories;
using FitHubApplication.Services;
using FitHubApplication.Services.ClaimFactory;
using FitHubApplication.Services.TokenFactory;
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
            Configuration.GetSection(ApplicationConsts.ConfigConsts.JwtBearer).Bind(jwtSettings);

            services.AddCors(options =>
            {
                string[] corsOrigins = Configuration[ApplicationConsts.CorsConsts.CorsOrigins].Split(ApplicationConsts.CorsConsts.Comma);

                options.AddPolicy(ApplicationConsts.CorsConsts.CorsPolicy,
                    builder =>
                    {
                        builder.WithOrigins(corsOrigins)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApplicationConsts.SwaggerConsts.ApiVersion, new OpenApiInfo
                {
                    Version = ApplicationConsts.SwaggerConsts.ApiVersion,
                    Title = ApplicationConsts.SwaggerConsts.FitHubAPI
                });
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}{ApplicationConsts.FileExtensionConsts.XmlExtension}";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<FitHubDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(ApplicationConsts.ConfigConsts.FitHubDbContext)), ServiceLifetime.Transient);

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

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddTransient<IUploadedFilesService, UploadedFilesService>();

            services.AddTransient<IUploadedFilesRepository, UploadedFilesRepository>();

            services.AddTransient<IGroupRepository, GroupRepository>();

            services.AddTransient<IGroupService, GroupService>();

            services.AddTransient<IGroupTraineeRepository, GroupTraineeRepository>();

            services.AddTransient<IEventRepository, EventRepository>();

            services.AddTransient<IEventService, EventService>();

            services.AddTransient<IExcerciseRepository, ExcerciseRepository>();

            services.AddTransient<IExerciseService, ExerciseService>();

            services.AddTransient<ITokenFactory, TokenFactory>();

            services.AddTransient<IClaimFactory, ClaimFactory>();

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
                options.SwaggerEndpoint(ApplicationConsts.SwaggerConsts.SwaggerJsonPath, ApplicationConsts.SwaggerConsts.SwaggerDocs);
            });

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}