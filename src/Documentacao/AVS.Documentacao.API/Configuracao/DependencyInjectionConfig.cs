using AVS.Banda.Application.AppServices;
using AVS.Banda.Application.AutoMapper;
using AVS.Banda.Application.Commands.Albuns;
using AVS.Banda.Application.Commands.Bandas;
using AVS.Banda.Application.Commands.Handlers;
using AVS.Banda.Application.Commands.Musicas;
using AVS.Banda.Application.Commands.Playlists;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Application.Queries.Albuns;
using AVS.Banda.Application.Queries.Bandas;
using AVS.Banda.Application.Queries.Handlers;
using AVS.Banda.Application.Queries.Musicas;
using AVS.Banda.Application.Queries.Playlists;
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
using AVS.Infra.CrossCutting.AzureBlob;
using AVS.Infra.CrossCutting.Interfaces;
using AVS.Infra.Data;
using FluentValidation.Results;
using MediatR;

namespace AVS.Documentacao.API.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Mediator
            //Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            #endregion

            #region Usuario Comandos
            //Usuario Comandos
            services.AddScoped<IRequestHandler<AdicionarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtivarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<InativarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            #endregion

            #region Banda Comandos
            //Banda Comandos
            services.AddScoped<IRequestHandler<AdicionarBandaCommand, ValidationResult>, BandaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarBandaCommand, ValidationResult>, BandaCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirBandaCommand, ValidationResult>, BandaCommandHandler>();
            #endregion

            #region Album Comandos
            //Album Comandos
            services.AddScoped<IRequestHandler<AdicionarAlbumCommand, ValidationResult>, AlbumCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarAlbumCommand, ValidationResult>, AlbumCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirAlbumCommand, ValidationResult>, AlbumCommandHandler>();
            #endregion

            #region Musica Comandos
            //Musica Comandos
            services.AddScoped<IRequestHandler<AdicionarMusicaCommand, ValidationResult>, MusicaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarMusicaCommand, ValidationResult>, MusicaCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirMusicaCommand, ValidationResult>, MusicaCommandHandler>();
            #endregion

            #region Playlist Comandos
            //Playlist Comandos
            services.AddScoped<IRequestHandler<AdicionarPlaylistCommand, ValidationResult>, PlaylistCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarPlaylistCommand, ValidationResult>, PlaylistCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirPlaylistCommand, ValidationResult>, PlaylistCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarMusicaPlaylistCommand, ValidationResult>, PlaylistCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirMusicaPlaylistCommand, ValidationResult>, PlaylistCommandHandler>();
            #endregion

            #region Usuario Queries
            //Usuario Queries 
            services.AddScoped<IRequestHandler<ObterTodosUsuariosQuery, ObterTodosUsuariosQueryResponse>, UsuarioQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodosUsuariosAtivosQuery, ObterTodosUsuariosQueryResponse>, UsuarioQueryHandler>();
            services.AddScoped<IRequestHandler<ObterDetalheUsuarioQuery, ObterDetalheUsuarioQueryResponse>, UsuarioQueryHandler>();
            #endregion

            #region Banda Queries
            //Banda Queries
            services.AddScoped<IRequestHandler<ObterTodasBandasQuery, ObterTodasBandasQueryResponse>, BandaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodasBandasPorNomeQuery, ObterTodasBandasQueryResponse>, BandaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterDetalheBandaQuery, ObterDetalheBandaQueryResponse>, BandaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterBandaPorIdQuery, ObterBandaPorIdQueryResponse>, BandaQueryHandler>();
            #endregion

            #region Album Queries
            //Album Queries
            services.AddScoped<IRequestHandler<ObterTodosAlbunsQuery, ObterTodosAlbunsQueryResponse>, AlbumQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodosAlbunsPorNomeQuery, ObterTodosAlbunsQueryResponse>, AlbumQueryHandler>();
            services.AddScoped<IRequestHandler<ObterDetalheAlbumQuery, ObterDetalheAlbumQueryResponse>, AlbumQueryHandler>();
            services.AddScoped<IRequestHandler<ObterAlbumPorIdQuery, ObterAlbumPorIdQueryResponse>, AlbumQueryHandler>();
            #endregion

            #region Musica Queries
            //Musica Queries
            services.AddScoped<IRequestHandler<ObterTodasMusicasQuery, ObterTodasMusicasQueryResponse>, MusicaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodasMusicasPorNomeQuery, ObterTodasMusicasPorNomeQueryResponse>, MusicaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterDetalheMusicaQuery, ObterDetalheMusicaQueryResponse>, MusicaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterMusicaPorIdQuery, ObterMusicaPorIdQueryResponse>, MusicaQueryHandler>();
            #endregion

            #region Playlist Queries
            //Playlist Queries
            services.AddScoped<IRequestHandler<ObterTodasPlaylistsQuery, ObterTodasPlaylistsQueryResponse>, PlaylistQueryHandler>();
            services.AddScoped<IRequestHandler<ObterTodasPlaylistsPorNomeQuery, ObterTodasPlaylistsPorNomeQueryResponse>, PlaylistQueryHandler>();
            services.AddScoped<IRequestHandler<ObterDetalhePlaylistQuery, ObterDetalhePlaylistQueryResponse>, PlaylistQueryHandler>();
            services.AddScoped<IRequestHandler<ObterPlaylistComMusicasQuery, ObterPlaylistComMusicasQueryResponse>, PlaylistQueryHandler>();
            #endregion

            #region Data
            //Data
            services.AddScoped<SpotifyCloneContext>();
            services.AddScoped(typeof(GenericRepository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<IBandaRepository, BandaRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IMusicaRepository, MusicaRepository>();
            services.AddScoped<IMusicaPlaylistRepository, MusicaPlaylistRepository>();
            #endregion

            #region Service
            //Service
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<IBandaService, BandaService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IMusicaService, MusicaService>();
            services.AddScoped<IMusicaPlaylistService, MusicaPlaylistService>();
            #endregion

            #region Service externo
            services.AddScoped<IAzureBlobStorage, AzureBlobStorage>();
            #endregion

            #region Application
            //Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IPlaylistAppService, PlaylistAppService>();
            services.AddScoped<IBandaAppService, BandaAppService>();
            services.AddScoped<IAlbumAppService, AlbumAppService>();
            services.AddScoped<IMusicaAppService, MusicaAppService>();
            services.AddScoped<IMusicaPlaylistAppService, MusicaPlaylistAppService>();
            #endregion

            #region AutoMapper
            //AutoMapper
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile).Assembly);
            services.AddAutoMapper(typeof(Cadastro.Application.AutoMapper.DomainToDtoMappingProfile).Assembly);
            #endregion
        }
    }
}
