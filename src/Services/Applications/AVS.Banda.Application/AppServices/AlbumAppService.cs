using AutoMapper;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Application.AppServices
{
    public class AlbumAppService : IAlbumAppService
    {
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public AlbumAppService(IAlbumService albumService, IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlbumResponseDto>> ObterTodos()
        {
            var albuns = await _albumService.ObterTodos();            
            if (albuns == null) return null;
            var response = _mapper.Map<IList<AlbumResponseDto>>(albuns);
            return response;            
        }

        public async Task<IEnumerable<AlbumResponseDto>> BuscarTodosPorCriterio(Expression<Func<Album, bool>> expression)
        {
            var albuns = await _albumService.BuscarTodosPorCriterio(expression);
            if (albuns == null) return null;
            var response = _mapper.Map<IList<AlbumResponseDto>>(albuns);
            return response;
        }

        public async Task<AlbumResponseDto> BuscarPorCriterio(Expression<Func<Album, bool>> expression)
        {
            var album = await _albumService.BuscarPorCriterio(expression);
            if (album == null) return null;
            var response = _mapper.Map<AlbumResponseDto>(album);
            return response;
        }

        public async Task<AlbumResponseDto> ObterPorId(object id)
        {
            var album = await _albumService.ObterPorId(id);
            if (album == null) return null;
            var response = _mapper.Map<AlbumResponseDto>(album);
            return response;
        }

        public async Task Salvar(AlbumRequestDto request)
        {
            var album = _mapper.Map<Album>(request);
            album.Validar();
            await _albumService.Salvar(album);
        }

        public async Task Atualizar(AlbumRequestDto request)
        {
            var album = _mapper.Map<Album>(request);
            album.Validar();
            await _albumService.Atualizar(album);
        }

        public async Task Exluir(AlbumRequestDto request)
        {
            var album = _mapper.Map<Album>(request);
            album.Validar();
            await _albumService.Exluir(album);
        }
    }
}
