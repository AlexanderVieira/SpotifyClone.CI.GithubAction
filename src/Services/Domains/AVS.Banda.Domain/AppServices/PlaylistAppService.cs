using AVS.Banda.Domain.AppServices.DTOs;
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
            Validacao.ValidarSeExiste(playlists.Cast<object>().ToList(), "Não existem dados para exibição.");
            IEnumerable<PlaylistDTO> playlistDTOs = new List<PlaylistDTO>();
            foreach (var playlist in playlists)
            {
                var playlistDTO = PlaylistDTO.ConverterParaPlaylistDTO(playlist);
                playlistDTOs = playlistDTOs.Append(playlistDTO);
            }
            return playlistDTOs;
        }

        public async Task<PlaylistDTO> ObterPorId(object id)
        {
            var playlist = await _playlistService.ObterPorId(id);
            Validacao.ValidarSeNulo(playlist, "Playlist não encontrada.");
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
            var playlist = PlaylistDTO.ConverterParaPlaylist(entity);
            playlist.Validar();
            await _playlistService.Exluir(playlist);
        }
    }
}
