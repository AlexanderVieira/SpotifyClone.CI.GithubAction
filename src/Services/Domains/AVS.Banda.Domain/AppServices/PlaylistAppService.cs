using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.AppServices;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.ObjDoinio;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.AppServices
{
    public class PlaylistAppService : IPlaylistAppService
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistAppService(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        public Task<PlaylistDTO> BuscarPorCriterio(Expression<Func<PlaylistDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlaylistDTO>> BuscarTodosPorCriterio(Expression<Func<PlaylistDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }             

        public async Task<IEnumerable<PlaylistDTO>> ObterTodos()
        {
            var playlists = await _playlistService.ObterTodos();
            //Validacao.ValidarSeNulo(playlists.Cast<object>().ToList(), "Não existem dados para exibição.");
            if (playlists == null) return null;
            return playlists.Select(PlaylistDTO.ConverterParaPlaylistDTO);           
        }

        public async Task<PlaylistDTO> ObterPorId(object id)
        {
            var playlist = await _playlistService.ObterPorId(id);
            //Validacao.ValidarSeNulo(playlist, "Playlist não encontrada.");
            if (playlist == null) return null;
            var playlistDTO = PlaylistDTO.ConverterParaPlaylistDTO(playlist);
            return playlistDTO;
        }

        public async Task Salvar(PlaylistDTO entity)
        {
            var playlist = PlaylistDTO.ConverterParaPlaylist(entity);
            playlist.Validar();
            await _playlistService.Salvar(playlist);
        }

        public async Task Atualizar(PlaylistDTO entity)
        {
            var playlist = PlaylistDTO.ConverterParaPlaylist(entity);
            playlist.Validar();
            await _playlistService.Atualizar(playlist);
        }
        
        public async Task Exluir(PlaylistDTO entity)
        {
            Validacao.ValidarSeNulo(entity, "Opa! Ocorreu um erro.");
            var playlist = PlaylistDTO.ConverterParaPlaylist(entity);
            playlist.Validar();
            await _playlistService.Exluir(playlist);
        }

        public async Task<IEnumerable<PlaylistDTO>> BuscarTodosPorCriterio(Expression<Func<Playlist, bool>> expression)
        {            
            var playlists = await _playlistService.BuscarTodosPorCriterio(expression);
            return playlists.Select(PlaylistDTO.ConverterParaPlaylistDTO);
        }

        public async Task<PlaylistMusicasQueryAnomima> BuscarMusicasPlaylist(Expression<Func<Playlist, bool>> expression)
        {
            var musicasplaylist = await _playlistService.BuscarMusicasPlaylist(expression);
            return musicasplaylist;
            //return musicasplaylist.Select(MusicaDTO.ConverterParaMusicaDTO);
        }
    }
}
