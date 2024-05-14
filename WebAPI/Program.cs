using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Autofac.DependencyResolvers;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Entities;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.JWT;
using DataAccess.DependencyResolvers;
using Entities.Profiles.AutoMapperProfiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace YourNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).AddHostBuilder().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                    builder.RegisterModule(new AutoFacCoreModule());
                    builder.RegisterModule(new AutoFacDataAccessModule());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        services.AddHttpContextAccessor();
                        services.AddCors(options =>
                        {
                            options.AddPolicy("AllowOrigin",
                                builder => builder.WithOrigins("http://localhost:3000"));
                        });
                        services.AddControllers();
                        services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRM WEB API", Version = "v1" });
                        });
                        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                        var tokenOptions = hostContext.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
                        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
                        //.AddJwtBearer(options =>
                        //{
                        //    options.TokenValidationParameters = new TokenValidationParameters
                        //    {
                        //        ValidateIssuer = true,
                        //        ValidateAudience = true,
                        //        ValidateLifetime = true,
                        //        ValidIssuer = tokenOptions.Issuer,
                        //        ValidAudience = tokenOptions.Audience,
                        //        ValidateIssuerSigningKey = true,
                        //        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                        //    };
                        //});

                        services.AddDependencyResolvers(new IDependencyInjectionModule[] {
                            new CoreModule(),
                            new DataAccessModule(),
                            new BusinessModule()
                        });

                        services.AddAutoMapper(typeof(EntitiesAutoMapperProfile));
                    })
                    .Configure(app =>
                    {
                        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
                        if (env.IsDevelopment() || env.IsProduction())
                        {
                            app.UseDeveloperExceptionPage();
                            app.UseSwagger();
                            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRM v1.0"));
                        }

                        var corsSettings = app.ApplicationServices.GetRequiredService<IConfiguration>()
                            .GetSection("CorsSettings").Get<CorsSettings>();
                        app.ConfigureCustomExceptionMiddleware();
                        app.UseCors(builder => builder.WithOrigins(Environment.GetEnvironmentVariable("ORIGINS").Split(',')).AllowAnyHeader());
                        //app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());


                        app.UseRouting();
                        app.UseStaticFiles();

                        app.UseAuthentication();
                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}