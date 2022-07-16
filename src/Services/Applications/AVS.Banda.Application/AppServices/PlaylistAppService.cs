using AutoMapper;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Application.AppServices
{
    public class PlaylistAppService : IPlaylistAppService
    {
        private readonly IPlaylistService _playlistService;
        private readonly IMapper _mapper;

        public PlaylistAppService(IPlaylistService playlistService, IMapper mapper)
        {
            _playlistService = playlistService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlaylistResponseDto>> ObterTodos()
        {
            var playlists = await _playlistService.ObterTodos();            
            if (playlists == null) return null;
            var response = _mapper.Map<IList<PlaylistResponseDto>>(playlists);
            return response;
        }

        public async Task<PlaylistResponseDto> ObterPorId(object id)
        {
            var playlist = await _playlistService.ObterPorId(id);            
            if (playlist == null) return null;
            var response = _mapper.Map<PlaylistResponseDto>(playlist);
            return response;
        }

        public async Task Salvar(PlaylistRequestDto request)
        {
            var playlist = _mapper.Map<Playlist>(request);
            playlist.Validar();
            await _playlistService.Salvar(playlist);
        }

        public async Task Atualizar(PlaylistRequestDto request)
        {
            var playlist = _mapper.Map<Playlist>(request);
            playlist.Validar();
            await _playlistService.Atualizar(playlist);
        }
        
        public async Task Exluir(PlaylistRequestDto request)
        {
            var playlist = _mapper.Map<Playlist>(request);
            playlist.Validar();
            await _playlistService.Exluir(playlist);
        }

        public async Task<IEnumerable<PlaylistResponseDto>> BuscarTodosPorCriterio(Expression<Func<Playlist, bool>> expression)
        {            
            var playlists = await _playlistService.BuscarTodosPorCriterio(expression);
            if (playlists == null) return null;
            var response = _mapper.Map<IList<PlaylistResponseDto>>(playlists);
            return response;

        }

        public async Task<PlaylistMusicasQueryAnonimaResponseDto> BuscarPlaylistComMusicas(Expression<Func<Playlist, bool>> expression)
        {
            var playlist = await _playlistService.BuscarPlaylistComMusicas(expression);
            var response = _mapper.Map<PlaylistMusicasQueryAnonimaResponseDto>(playlist);
            return response;
        }

        public async Task<IEnumerable<PlaylistMusicasQueryAnonimaResponseDto>> BuscarPlaylistsPorCriterio(Expression<Func<Playlist, bool>> expression)
        {
            var playlists = await _playlistService.BuscarPlaylistsPorCriterio(expression);
            var response = _mapper.Map<IList<PlaylistMusicasQueryAnonimaResponseDto>>(playlists);
            return response;
        }
    }
}
