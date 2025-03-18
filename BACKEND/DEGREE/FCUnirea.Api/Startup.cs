using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FCUnirea.Business;
using FCUnirea.Api.Middleware;
using FCUnirea.Persistance;
using FCUnirea.Api.Validators;

namespace FCUnirea.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Înregistrăm controlerele și FluentValidation
            services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<UsersModelValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<LoginModelValidator>();
                });

            // Înregistrăm Swagger pentru documentație API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FCUnirea.Api",
                    Version = "v1",
                    Description = "API pentru gestionarea utilizatorilor și statisticilor echipei FC Unirea."
                });
            });

            // Înregistrăm serviciile specifice ale aplicației
            services.AddPersistanceServices(Configuration);
            services.AddBusinessServices();

            // Configurare CORS pentru a permite accesul din frontend Angular
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FCUnirea.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // Activăm politica CORS definită mai sus
            app.UseCors("AllowAll");

            // Gestionare excepții personalizată
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
