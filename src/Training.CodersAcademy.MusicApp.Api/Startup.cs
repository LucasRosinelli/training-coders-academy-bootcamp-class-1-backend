using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Training.CodersAcademy.MusicApp.Api.Extensions;
using Training.CodersAcademy.MusicApp.Api.Repository;

namespace Training.CodersAcademy.MusicApp.Api
{
    /// <summary>
    /// Configures services and the app's request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The configuration properties.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/>.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures services before configuring the pipeline.
        /// </summary>
        /// <param name="services">The collection of services descriptors.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<MusicAppContext>(config =>
            {
                config.UseProvider(Configuration);
            });

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddScoped<AlbumRepository>();
            services.AddScoped<MusicRepository>();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Coders Academy - MusicApp API",
                        Version = "v1",
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Creates the app's request processing pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <param name="env">The hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Coders Academy - MusicApp API v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
