using AVS.Banda.Application.AppServices;
using AVS.Banda.Application.AutoMapper;
using AVS.Banda.Application.Commands;
using AVS.Banda.Application.Commands.Handlers;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Application.Queries;
using AVS.Banda.Data.Repositories;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Banda.Domain.Services;
using AVS.Cadastro.Application.AppServices;
using AVS.Cadastro.Application.Commands;
using AVS.Cadastro.Application.Commands.Handlers;
using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Application.Queries;
using AVS.Cadastro.Data.Repositories;
using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Cadastro.Domain.Interfaces.Services;
using AVS.Cadastro.Domain.Services;
using AVS.Core.Comunicacao.Mediator;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;
using FluentValidation.Results;
using MediatR;

namespace AVS.Documentacao.API.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Usuario Comandos
            services.AddScoped<IRequestHandler<AdicionarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtivarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<InativarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();

            //Usuario Queries 
            services.AddScoped<IRequestHandler<ObterTodosUsuariosQuery, ObterTodosUsuariosQueryResponse>, UsuarioQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodosUsuariosAtivosQuery, ObterTodosUsuariosQueryResponse>, UsuarioQueryHandler>();
            services.AddScoped<IRequestHandler<ObterDetalheUsuarioQuery, ObterDetalheUsuarioQueryResponse>, UsuarioQueryHandler>();

            //Banda Comandos
            services.AddScoped<IRequestHandler<AdicionarBandaCommand, ValidationResult>, BandaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarBandaCommand, ValidationResult>, BandaCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirBandaCommand, ValidationResult>, BandaCommandHandler>();

            //Banda Queries
            services.AddScoped<IRequestHandler<ObterTodasBandasQuery, ObterTodasBandasQueryResponse>, BandaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodasBandasPorNomeQuery, ObterTodasBandasQueryResponse>, BandaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterDetalheBandaQuery, ObterDetalheBandaQueryResponse>, BandaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterBandaPorIdQuery, ObterBandaPorIdQueryResponse>, BandaQueryHandler>();

            //Data
            services.AddScoped<SpotifyCloneContext>();
            services.AddScoped(typeof(GenericRepository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<IBandaRepository, BandaRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IMusicaRepository, MusicaRepository>();
            services.AddScoped<IMusicaPlaylistRepository, MusicaPlaylistRepository>();

            //Service
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<IBandaService, BandaService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IMusicaService, MusicaService>();
            services.AddScoped<IMusicaPlaylistService, MusicaPlaylistService>();

            //Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IPlaylistAppService, PlaylistAppService>();
            services.AddScoped<IBandaAppService, BandaAppService>();
            services.AddScoped<IAlbumAppService, AlbumAppService>();
            services.AddScoped<IMusicaAppService, MusicaAppService>();
            services.AddScoped<IMusicaPlaylistAppService, MusicaPlaylistAppService>();

            //AutoMapper
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile).Assembly);
            services.AddAutoMapper(typeof(Cadastro.Application.AutoMapper.DomainToDtoMappingProfile).Assembly);
        }
    }
}
