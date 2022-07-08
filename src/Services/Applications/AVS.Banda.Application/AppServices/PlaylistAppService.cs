using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.ObjDoinio;
using System.Linq.Expressions;

namespace AVS.Banda.Application.AppServices
{
    public class PlaylistAppService : IPlaylistAppService
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistAppService(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        public async Task<IEnumerable<PlaylistResponseDto>> ObterTodos()
        {
            var playlists = await _playlistService.ObterTodos();
            //Validacao.ValidarSeNulo(playlists.Cast<object>().ToList(), "Não existem dados para exibição.");
            if (playlists == null) return null;
            return new List<PlaylistResponseDto>();
            //return playlists.Select(PlaylistDTO.ConverterParaPlaylistDTO);           
        }

        public async Task<PlaylistResponseDto> ObterPorId(object id)
        {
            var playlist = await _playlistService.ObterPorId(id);
            //Validacao.ValidarSeNulo(playlist, "Playlist não encontrada.");
            if (playlist == null) return null;
            //var playlistDTO = PlaylistDTO.ConverterParaPlaylistDTO(playlist);
            return null;
        }

        public async Task Salvar(PlaylistRequestDto request)
        {
            //var playlist = PlaylistDTO.ConverterParaPlaylist(request);
            //playlist.Validar();
            //await _playlistService.Salvar(playlist);
        }

        public async Task Atualizar(PlaylistRequestDto request)
        {
            //var playlist = PlaylistDTO.ConverterParaPlaylist(request);
            //playlist.Validar();
            //await _playlistService.Atualizar(playlist);
        }
        
        public async Task Exluir(PlaylistRequestDto request)
        {
            Validacao.ValidarSeNulo(request, "Opa! Ocorreu um erro.");
            //var playlist = PlaylistDTO.ConverterParaPlaylist(request);
            //playlist.Validar();
            //await _playlistService.Exluir(playlist);
        }

        public async Task<IEnumerable<PlaylistResponseDto>> BuscarTodosPorCriterio(Expression<Func<Playlist, bool>> expression)
        {            
            var playlists = await _playlistService.BuscarTodosPorCriterio(expression);
            return new List<PlaylistResponseDto>();
            //return playlists.Select(PlaylistDTO.ConverterParaPlaylistDTO);
        }

        public async Task<PlaylistMusicasQueryAnomima> BuscarMusicasPlaylist(Expression<Func<Playlist, bool>> expression)
        {
            var musicasplaylist = await _playlistService.BuscarMusicasPlaylist(expression);
            return musicasplaylist;            
        }        
        
    }
}
