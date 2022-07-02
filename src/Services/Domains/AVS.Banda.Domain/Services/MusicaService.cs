using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Services
{
    public class MusicaService : GenericService<Musica>, IMusicaService
    {
        private readonly IMusicaRepository _musicaRepository;
        public MusicaService(IMusicaRepository musicaRepository) : base(musicaRepository)
        {
            _musicaRepository = musicaRepository;
        }

        public async Task<IEnumerable<MusicaAlbumQueryAnonima>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression)
        {
            return await _musicaRepository.BuscarTodosPorCriterio(expression);
        }
    }
}
