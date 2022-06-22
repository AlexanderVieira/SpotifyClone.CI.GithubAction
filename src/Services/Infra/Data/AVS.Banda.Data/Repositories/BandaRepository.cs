using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;

namespace AVS.Banda.Data.Repositories
{
    public class BandaRepository : GenericRepository<Domain.Entities.Banda>, IBandaRepository
    {
        public BandaRepository(SpotifyCloneContext context) : base(context)
        {
        }
    }
}
