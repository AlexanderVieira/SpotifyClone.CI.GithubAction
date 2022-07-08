using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Application.AppServices
{
    public class MusicaAppService : IMusicaAppService
    {
        private readonly IMusicaService _musicaService;

        public MusicaAppService(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        public Task<MusicaResponseDto> BuscarPorCriterio(Expression<Func<MusicaRequestDto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MusicaResponseDto>> BuscarTodosPorCriterio(Expression<Func<MusicaRequestDto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MusicaAlbumQueryAnonima>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression)
        {
            var musicas = await _musicaService.BuscarTodosPorCriterio(expression);
            if (musicas == null) return null;
            return musicas;
            //return musicas.Select(MusicaDTO.ConverterParaMusicaDTO);
        }

        public async Task Salvar(MusicaRequestDto request)
        {
            //var musica = MusicaDTO.ConverterParaMusica(entity);
            //musica.Validar();
            //await _musicaService.Salvar(musica);
        }

        public async Task Atualizar(MusicaRequestDto request)
        {
            //var musica = MusicaDTO.ConverterParaMusica(entity);
            //musica.Validar();
            //await _musicaService.Atualizar(musica);
        }

        public Task Exluir(MusicaRequestDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<MusicaResponseDto> ObterPorId(object id)
        {
            var musica = await _musicaService.ObterPorId(id);
            if (musica == null) return null;
            return null;
            //return MusicaDTO.ConverterParaMusicaDTO(musica);
        }

        public async Task<IEnumerable<MusicaResponseDto>> ObterTodos()
        {
            var musicas = await _musicaService.ObterTodos();
            if (musicas == null) return null;
            return null;
            //return musicas.Select(MusicaDTO.ConverterParaMusicaDTO);
        }

    }
}
