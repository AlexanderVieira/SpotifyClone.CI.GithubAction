using AVS.Core.Extensions;
using AVS.Infra.Data;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AVS.Documentacao.API.Configuracao
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                    .AddSqlServer(
                        connectionString: configuration.GetConnectionString("DefaultConnection"),
                        healthQuery: "SELECT 1;",
                        name: "Database",
                        failureStatus: HealthStatus.Unhealthy
                     );

            services.AddHealthChecksUI(opt =>
            {
                opt.AddHealthCheckEndpoint("Documentacao API", configuration.GetSection("HealthCheckUrl").Value);
            })
             .AddInMemoryStorage();

            services.AddDbContext<SpotifyCloneContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<PopulaBanco>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddHttpClient();

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            if (app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseItToSeedSqlServer();                
            }
            
            app.UseHttpsRedirection();
            app.UseCors("Total");
            app.UseAuthorization();            
            app.MapControllers();
            app.UseRouting()
            .UseEndpoints(config =>
            {
                config.MapHealthChecks("/healthcheck", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                config.MapHealthChecksUI(options => options.UIPath = "/dashboard");
            });
        }
    }
}
