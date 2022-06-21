using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Interfaces.AppServices;
using AVS.Banda.Domain.Interfaces.Services;
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

        public Task Atualizar(PlaylistDTO entity)
        {
            throw new NotImplementedException();
        }
                
        public Task<PlaylistDTO> BuscarPorCriterio(Expression<Func<PlaylistDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }
               
        public Task<IEnumerable<PlaylistDTO>> BuscarTodosPorCriterio(Expression<Func<PlaylistDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }                             

        public Task Exluir(PlaylistDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistDTO> ObterPorId(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlaylistDTO>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public async Task Salvar(PlaylistDTO entity)
        {
            var playlist = PlaylistDTO.ConverterParaPlaylist(entity);
            await _playlistService.Salvar(playlist);
        }
        
    }
}
