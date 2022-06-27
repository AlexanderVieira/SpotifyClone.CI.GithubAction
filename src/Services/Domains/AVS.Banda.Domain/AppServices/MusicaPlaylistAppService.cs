using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.AppServices;
using AVS.Banda.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.AppServices
{
    public class MusicaPlaylistAppService : IMusicaPlaylistAppService
    {
        private readonly IMusicaPlaylistService _musicaPlaylistService;

        public MusicaPlaylistAppService(IMusicaPlaylistService musicaPlaylistService)
        {
            _musicaPlaylistService = musicaPlaylistService;
        }

        public Task Atualizar(MusicaPlaylistDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<MusicaPlaylistDTO> BuscarPorCriterio(Expression<Func<MusicaPlaylistDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MusicaPlaylistDTO>> BuscarTodosPorCriterio(Expression<Func<MusicaPlaylistDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task Exluir(MusicaPlaylistDTO entity)
        {
            var musicaPlaylist = new MusicaPlaylist { PlaylistId = entity.PlaylistId, MusicaId = entity.MusicaId };
            await _musicaPlaylistService.Exluir(musicaPlaylist);
        }

        public Task<MusicaPlaylistDTO> ObterPorId(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MusicaPlaylistDTO>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public async Task Salvar(MusicaPlaylistDTO entity)
        {
            var musicaPlaylist = new MusicaPlaylist { PlaylistId = entity.PlaylistId, MusicaId = entity.MusicaId }; 
            await _musicaPlaylistService.Salvar(musicaPlaylist);
        }
    }
}
