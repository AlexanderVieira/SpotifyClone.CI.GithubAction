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

        public async Task<IEnumerable<MusicaQueryAnonima>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression)
        {
            return await Query
                .Where(expression)
                .AsNoTrackingWithIdentityResolution()                
                .Select(p => new MusicaQueryAnonima
                {
                    Id = p.Id,                    
                    AlbumId = p.AlbumId, 
                    Nome = p.Nome,                     
                    DuracaoFormatada = p.Duracao.Formatado,
                    TituloAlbum = p.Album.Titulo
                })
                .ToListAsync();
        }

        public async Task<MusicaQueryAnonima> BuscarPorCriterio(Expression<Func<Musica, bool>> expression)
        {
            return await Query
                .Where(expression)
                .AsNoTrackingWithIdentityResolution()
                .Select(p => new MusicaQueryAnonima
                {
                    Id = p.Id,
                    AlbumId = p.AlbumId,
                    Nome = p.Nome,                    
                    DuracaoFormatada = p.Duracao.Formatado,
                    TituloAlbum = p.Album.Titulo
                })
                .FirstOrDefaultAsync();
        }
    }
}
