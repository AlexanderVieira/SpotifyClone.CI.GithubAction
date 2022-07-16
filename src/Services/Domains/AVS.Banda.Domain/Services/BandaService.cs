using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Services
{
    public class BandaService : GenericService<Entities.Banda>, IBandaService
    {
        private readonly IBandaRepository _bandaRepository;
        public BandaService(IBandaRepository bandaRepository) : base(bandaRepository)
        {
            _bandaRepository = bandaRepository;
        }

        public async Task<Entities.Banda> BuscarPorCriterio(Expression<Func<Entities.Banda, bool>> expression)
        {
            return await _bandaRepository.BuscarPorCriterio(expression);
        }

    }
}
