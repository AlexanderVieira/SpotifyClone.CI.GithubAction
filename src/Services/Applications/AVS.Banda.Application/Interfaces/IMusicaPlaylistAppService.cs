using AVS.Banda.Application.DTOs;

namespace AVS.Banda.Application.Interfaces
{
    public interface IMusicaPlaylistAppService
    {
        Task Salvar(MusicaPlaylistRequestDto request);
        Task Exluir(MusicaPlaylistRequestDto request);
    }
}
 