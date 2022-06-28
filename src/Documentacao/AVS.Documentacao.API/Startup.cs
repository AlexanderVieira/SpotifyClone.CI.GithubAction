﻿using AVS.Documentacao.API.Configuracao;

namespace AVS.Documentacao.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddApiConfiguration(Configuration);
            services.AddSwaggerGen();            
            services.RegisterServices();
        }

        public void Configure(WebApplication app)
        {            
            app.UseApiConfiguration();
        }
    }
}