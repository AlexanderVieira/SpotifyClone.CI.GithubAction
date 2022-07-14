using AutoMapper;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Application.AppServices
{
    public class MusicaPlaylistAppService : IMusicaPlaylistAppService
    {
        private readonly IMusicaPlaylistService _musicaPlaylistService;
        private readonly IMapper _mapper;

        public MusicaPlaylistAppService(IMusicaPlaylistService musicaPlaylistService, IMapper mapper)
        {
            _musicaPlaylistService = musicaPlaylistService;
            _mapper = mapper;
        }

        public async Task Salvar(MusicaPlaylistRequestDto request)
        {
            var musicaPlaylist = _mapper.Map<MusicaPlaylist>(request);
            musicaPlaylist.Validar();
            await _musicaPlaylistService.Salvar(musicaPlaylist);
        }

        public async Task Exluir(MusicaPlaylistRequestDto request)
        {
            var musicaPlaylist = _mapper.Map<MusicaPlaylist>(request);
            musicaPlaylist.Validar();
            await _musicaPlaylistService.Exluir(musicaPlaylist);
        }

        public async Task<MusicaPlaylistResponseDto> BuscarPorCriterio(Expression<Func<MusicaPlaylist, bool>> expression)
        {
            var musicaPlaylist = await _musicaPlaylistService.BuscarPorCriterio(expression);
            if (musicaPlaylist == null) return null;
            var response = _mapper.Map<MusicaPlaylistResponseDto>(musicaPlaylist);
            return response;
        }

        public async Task<bool> Commit()
        {
            return await _musicaPlaylistService.Commit();
        }
    }
}
