using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Domain.Interfaces.Services;

namespace AVS.Banda.Application.AppServices
{
    public class MusicaPlaylistAppService : IMusicaPlaylistAppService
    {
        private readonly IMusicaPlaylistService _musicaPlaylistService;

        public MusicaPlaylistAppService(IMusicaPlaylistService musicaPlaylistService)
        {
            _musicaPlaylistService = musicaPlaylistService;
        }       

        public async Task Salvar(MusicaPlaylistRequestDto request)
        {
            var musicaPlaylist = new MusicaPlaylistRequestDto(request.PlaylistId, request.MusicaId);
            //await _musicaPlaylistService.Salvar(musicaPlaylist);
        }

        public async Task Exluir(MusicaPlaylistRequestDto request)
        {
            var musicaPlaylist = new MusicaPlaylistRequestDto(request.PlaylistId, request.MusicaId);
            ///await _musicaPlaylistService.Exluir(musicaPlaylist);
        }
    }
}
