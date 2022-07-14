using AutoMapper;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Application.AppServices
{
    public class MusicaAppService : IMusicaAppService
    {
        private readonly IMusicaService _musicaService;
        private readonly IMapper _mapper;

        public MusicaAppService(IMusicaService musicaService, IMapper mapper)
        {
            _musicaService = musicaService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MusicaResponseDto>> ObterTodos()
        {
            var musicas = await _musicaService.ObterTodos();
            if (musicas == null) return null;
            var response = _mapper.Map<IList<MusicaResponseDto>>(musicas);
            return response;
        }

        public async Task<IEnumerable<MusicaAlbumResponseDto>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression)
        {
            var musicas = await _musicaService.BuscarTodosPorCriterio(expression);
            if (musicas == null) return null;
            var response = _mapper.Map<IList<MusicaAlbumResponseDto>>(musicas);
            return response;            
        }

        public async Task<MusicaAlbumResponseDto> BuscarPorCriterio(Expression<Func<Musica, bool>> expression)
        {
            var musica = await _musicaService.BuscarPorCriterio(expression);
            if (musica == null) return null;
            var response = _mapper.Map<MusicaAlbumResponseDto>(musica);
            return response;
        }

        public async Task<MusicaResponseDto> ObterPorId(object id)
        {
            var musica = await _musicaService.ObterPorId(id);
            if (musica == null) return null;
            var response = _mapper.Map<MusicaResponseDto>(musica);
            return response;
        }

        public async Task Salvar(MusicaRequestDto request)
        {            
            var musica = _mapper.Map<Musica>(request);
            musica.Validar();
            await _musicaService.Salvar(musica);
        }

        public async Task Atualizar(MusicaRequestDto request)
        {
            var musica = _mapper.Map<Musica>(request);
            musica.Validar();
            await _musicaService.Atualizar(musica);
        }

        public async Task Exluir(MusicaRequestDto request)
        {
            var musica = _mapper.Map<Musica>(request);
            musica.Validar();
            await _musicaService.Exluir(musica);
        }
    }
}
