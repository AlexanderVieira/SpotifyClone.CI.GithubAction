﻿using AVS.Banda.Data.Repositories;
using AVS.Banda.Domain.AppServices;
using AVS.Banda.Domain.Interfaces.AppServices;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Banda.Domain.Services;
using AVS.Cadastro.Application.AppServices;
using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Data.Repositories;
using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Cadastro.Domain.Interfaces.Services;
using AVS.Cadastro.Domain.Services;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;

namespace AVS.Documentacao.API.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Data
            services.AddScoped<SpotifyCloneContext>();
            services.AddScoped(typeof(GenericRepository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();

            //Service
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPlaylistService, PlaylistService>();

            //Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IPlaylistAppService, PlaylistAppService>();            
        }
    }
}
