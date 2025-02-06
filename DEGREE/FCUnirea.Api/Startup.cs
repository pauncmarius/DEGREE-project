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
using FCUnirea.Api.Filters;
using FCUnirea.Persistance;


namespace FCUnirea.Api
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
            BuildMvc(services);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FCUnirea.Api", Version = "v1" });

                // Custom Schema Id Generator for different classes
                c.MapType<FCUnirea.Domain.Entities.CompetitionType>(() => new OpenApiSchema { Type = "string", Description = "Custom Description for Domain CompetitionType" });
                c.MapType<FCUnirea.Business.Models.CompetitionType>(() => new OpenApiSchema { Type = "string", Description = "Custom Description for Business CompetitionType" });
                
                c.MapType<FCUnirea.Domain.Entities.TeamType>(() => new OpenApiSchema { Type = "string", Description = "Custom Description for Domain TeamType" });
                c.MapType<FCUnirea.Business.Models.TeamType>(() => new OpenApiSchema { Type = "string", Description = "Custom Description for Business TeamType" });
                
                c.MapType<FCUnirea.Domain.Entities.SeatType>(() => new OpenApiSchema { Type = "string", Description = "Custom Description for Domain SeatType" });
                c.MapType<FCUnirea.Business.Models.SeatType>(() => new OpenApiSchema { Type = "string", Description = "Custom Description for Business SeatType" });

                c.MapType<FCUnirea.Domain.Entities.Position>(() => new OpenApiSchema { Type = "string", Description = "Custom Description for Domain Position" });
                c.MapType<FCUnirea.Business.Models.Position>(() => new OpenApiSchema { Type = "string", Description = "Custom Description for Business Position" });

                c.MapType<FCUnirea.Domain.Entities.UserRole>(() => new OpenApiSchema { Type = "string", Description = "Custom Description for Domain UserRole" });
                c.MapType<FCUnirea.Business.Models.UserRole>(() => new OpenApiSchema { Type = "string", Description = "Custom Description for Business UserRole" });
            });
            services.AddPersistanceServices(Configuration);
            services.AddBusinessServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void BuildMvc(IServiceCollection services)
        {
            services.AddMvc(options => { options.Filters.Add(typeof(ValidationFilter)); })
                .AddFluentValidation(c => { c.RegisterValidatorsFromAssemblyContaining<Startup>(); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
    }
}
