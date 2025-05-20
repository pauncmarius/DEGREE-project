//startup.cs
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FCUnirea.Business;
using FCUnirea.Persistance;
using FCUnirea.Api.Validators;
using FCUnirea.Business.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using FCUnirea.Domain.Email;
using FCUnirea.Business.Services.IServices;

namespace FCUnirea.Api
{
    public class Startup
    {
        // injecteaza configurarile aplicatiei, din appsettings.json
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // inregistram controlerele si fluentvalidation pentru validarea modelelor
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // ignora ciclurile de referinta la serializare json
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                    // serializeaza enum-urile ca string
                    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                })
                .AddFluentValidation(fv =>
                {
                    // inregistreaza validatorii din proiect pentru modelele de utilizator si login
                    fv.RegisterValidatorsFromAssemblyContaining<UsersModelValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<LoginModelValidator>();
                });

            // inregistram swagger pentru documentatia api
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FCUnirea.Api",
                    Version = "v1",
                    Description = "api pentru gestionarea utilizatorilor si statisticilor echipei fc unirea"
                });
            });

            // inregistram serviciile de infrastructura si business cu dependency injection
            services.AddPersistanceServices(Configuration);
            services.AddBusinessServices();

            // aici e serviciul pentru chat AI
            services.AddSingleton<OpenAiChatService>();


            // configuram serviciul de email cu setari din appsettings.json
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            // configuram cors ca sa permita accesul din frontend angular
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            // configuram setarile pentru jwt (autentificare cu token)
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            var jwtSettings = Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // seteaza parametrii pentru validarea tokenului jwt
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // activeaza pagina de exceptii si swagger in development
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FCUnirea.Api v1"));
            }

            // forteaza https
            app.UseHttpsRedirection();
            app.UseRouting();

            // activeaza politica de cors (pentru frontend)
            app.UseCors("AllowAll");

            // activeaza autentificarea si autorizarea
            app.UseAuthentication();
            app.UseAuthorization();

            // maparea endpointurilor catre controlere
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

