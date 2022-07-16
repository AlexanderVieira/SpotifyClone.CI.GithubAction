using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.Services;

namespace AVS.Banda.Domain.Services
{
    public class MusicaPlaylistService : GenericService<MusicaPlaylist>, IMusicaPlaylistService
    {
        private readonly IMusicaPlaylistRepository _musicaPlaylistRepository;
        public MusicaPlaylistService(IMusicaPlaylistRepository musicaPlaylistRepository) : base(musicaPlaylistRepository)
        {
            _musicaPlaylistRepository = musicaPlaylistRepository;
        }

        public async Task Salvar(MusicaPlaylist entity)
        {            
            await _musicaPlaylistRepository.Salvar(entity);
        }

        public async Task Excluir(MusicaPlaylist entity)
        {
            await _musicaPlaylistRepository.Salvar(entity);
        }

        public async Task<bool> Commit()
        {
            return await _musicaPlaylistRepository.UnitOfWork.Commit();
        }

    }
}
