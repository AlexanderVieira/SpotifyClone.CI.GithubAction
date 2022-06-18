using AVS.Cadastro.Application.AppServices;
using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Data;
using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Cadastro.Domain.Interfaces.Services;
using AVS.Cadastro.Domain.Services;

namespace AVS.Documentacao.API.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Data
            services.AddScoped<UsuarioContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Service
            services.AddScoped<IUsuarioService, UsuarioService>();

            //Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
        }
    }
}
