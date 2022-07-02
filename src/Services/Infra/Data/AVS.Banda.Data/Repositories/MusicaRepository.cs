using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AVS.Banda.Data.Repositories
{
    public class MusicaRepository : GenericRepository<Musica>, IMusicaRepository
    {
        public MusicaRepository(SpotifyCloneContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MusicaAlbumQueryAnonima>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression)
        {
            return await Query
                .Where(expression)
                .AsNoTrackingWithIdentityResolution()                
                .Select(p => new MusicaAlbumQueryAnonima
                {
                    Id = p.Id,                    
                    AlbumId = p.AlbumId, 
                    Nome = p.Nome, 
                    Duracao = p.Duracao.Valor, 
                    DuracaoFormatada = p.Duracao.Formatado,
                    AlbumTitulo = p.Album.Titulo
                })
                .ToListAsync();
        }
    }
}
