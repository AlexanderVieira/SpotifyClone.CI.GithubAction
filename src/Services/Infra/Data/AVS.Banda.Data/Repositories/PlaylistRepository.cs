using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AVS.Banda.Data.Repositories
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        private readonly SpotifyCloneContext _context;
        public PlaylistRepository(SpotifyCloneContext context) : base(context)
        {
            _context = context;
        }       

        public async Task<PlaylistMusicasQueryAnomima> BuscarMusicasPlaylist(Expression<Func<Playlist, bool>> expression)
        {
            var query = await _context.Playlists
                .Where(expression)
                .Select(p => new {
                    p.Id,
                    p.UsuarioId,
                    p.Titulo,
                    p.Descricao,
                    p.Foto,
                    Musicas = p.Musicas
                .Select(m => new { m.Musica.Id, m.Musica.Nome, m.Musica.Duracao, m.Musica.AlbumId, m.Musica.Album.Titulo })
                .AsEnumerable()
                }).FirstOrDefaultAsync();
            
            var plt = new PlaylistMusicasQueryAnomima(query.Id, query.Titulo, query.Descricao, query.Foto);
            var musicas = query.Musicas;
            
            foreach (var item in musicas)
            {
                var musicaTransporte = new MusicaQueryAnonima
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Duracao = item.Duracao.Formatado,
                    AlbumId = item.AlbumId,
                    AlbumTitulo = item.Titulo
                };
                plt.Musicas.Add(musicaTransporte);
            }

            return plt;
        }
    } 
    
}
