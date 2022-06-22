using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.Services;

namespace AVS.Banda.Domain.Services
{
    public class BandaService : GenericService<Entities.Banda>, IBandaService
    {
        public BandaService(IBandaRepository bandaRepository) : base(bandaRepository)
        {            
        }
       
    }
}
