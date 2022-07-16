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

        public async Task<PlaylistMusicasQueryAnonima> BuscarPlaylistComMusicas(Expression<Func<Playlist, bool>> expression)
        {
            var query = await _context.Playlists
                .Where(expression)
                .Select(p => new PlaylistMusicasQueryAnonima
                {
                    Id = p.Id,
                    UsuarioId = p.UsuarioId,
                    Titulo = p.Titulo,
                    Descricao = p.Descricao,
                    Foto = p.Foto,
                    Musicas = (IList<MusicaQueryAnonima>)p.Musicas
                    .Select(x => new MusicaQueryAnonima
                    {
                        Id = x.Musica.Id,
                        AlbumId = x.Musica.AlbumId,
                        Nome = x.Musica.Nome,
                        DuracaoFormatada = x.Musica.Duracao.Formatado,
                        TituloAlbum = x.Musica.Album.Titulo
                    })
                }).FirstOrDefaultAsync();

            return query;

        }                

        public async Task<IEnumerable<PlaylistMusicasQueryAnonima>> BuscarPlaylistsPorCriterio(Expression<Func<Playlist, bool>> expression)
        {
            var query = await _context.Playlists
                .Where(expression)
                .Select(p => new PlaylistMusicasQueryAnonima 
                { 
                    Id = p.Id, 
                    UsuarioId = p.UsuarioId, 
                    Titulo = p.Titulo, 
                    Descricao = p.Descricao, 
                    Foto = p.Foto, 
                    Musicas = (IList<MusicaQueryAnonima>)p.Musicas
                    .Select(x => new MusicaQueryAnonima 
                        { 
                            Id = x.Musica.Id, 
                            AlbumId = x.Musica.AlbumId, 
                            Nome = x.Musica.Nome, 
                            DuracaoFormatada = x.Musica.Duracao.Formatado, 
                            TituloAlbum = x.Musica.Album.Titulo
                        })
                }).ToListAsync();            

            return query;
        }
    } 
    
}
