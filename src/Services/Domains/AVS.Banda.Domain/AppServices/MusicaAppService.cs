using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.AppServices;
using AVS.Banda.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.AppServices
{
    public class MusicaAppService : IMusicaAppService
    {
        private readonly IMusicaService _musicaService;

        public MusicaAppService(IMusicaService musicaService)
        {
            _musicaService = musicaService;
        }

        public async Task Atualizar(MusicaDTO entity)
        {
            var musica = MusicaDTO.ConverterParaMusica(entity);
            musica.Validar();
            await _musicaService.Atualizar(musica);
        }

        public Task<MusicaDTO> BuscarPorCriterio(Expression<Func<MusicaDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MusicaDTO>> BuscarTodosPorCriterio(Expression<Func<MusicaDTO, bool>> expression)
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

        public Task Exluir(MusicaDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<MusicaDTO> ObterPorId(object id)
        {
            var musica = await _musicaService.ObterPorId(id);
            if (musica == null) return null;
            return MusicaDTO.ConverterParaMusicaDTO(musica);
        }

        public async Task<IEnumerable<MusicaDTO>> ObterTodos()
        {
            var musicas = await _musicaService.ObterTodos();
            if (musicas == null) return null;            
            return musicas.Select(MusicaDTO.ConverterParaMusicaDTO);
        }

        public Task Salvar(MusicaDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
