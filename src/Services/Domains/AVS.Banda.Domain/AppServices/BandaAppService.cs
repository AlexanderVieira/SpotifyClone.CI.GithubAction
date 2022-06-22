using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Interfaces.AppServices;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.ObjDoinio;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.AppServices
{
    public class BandaAppService : IBandaAppService
    {
        private readonly IBandaService _bandaService;

        public BandaAppService(IBandaService bandaService)
        {
            _bandaService = bandaService;
        }

        public Task<BandaDTO> BuscarPorCriterio(Expression<Func<BandaDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BandaDTO>> BuscarTodosPorCriterio(Expression<Func<BandaDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }             

        public async Task<IEnumerable<BandaDTO>> ObterTodos()
        {
            var bandas = await _bandaService.ObterTodos();
            Validacao.ValidarSeExiste(bandas.Cast<object>().ToList(), "Não existem dados para exibição.");
            IEnumerable<BandaDTO> bandaDTOs = new List<BandaDTO>();
            foreach (var banda in bandas)
            {
                var bandaDTO = BandaDTO.ConverterParaBandaDTO(banda);
                bandaDTOs = bandaDTOs.Append(bandaDTO);
            }
            return bandaDTOs;
        }

        public async Task<BandaDTO> ObterPorId(object id)
        {
            var banda = await _bandaService.ObterPorId(id);
            Validacao.ValidarSeNulo(banda, "Banda não encontrada.");
            var bandaDTO = BandaDTO.ConverterParaBandaDTO(banda);
            return bandaDTO;
        }

        public async Task Salvar(BandaDTO entity)
        {
            var banda = BandaDTO.ConverterParaBanda(entity);
            banda.Validar();
            await _bandaService.Salvar(banda);
        }

        public async Task Atualizar(BandaDTO entity)
        {
            var banda = BandaDTO.ConverterParaBanda(entity);
            banda.Validar();
            await _bandaService.Atualizar(banda);
        }
        
        public async Task Exluir(BandaDTO entity)
        {
            var banda = BandaDTO.ConverterParaBanda(entity);
            banda.Validar();
            await _bandaService.Exluir(banda);
        }
    }
}
