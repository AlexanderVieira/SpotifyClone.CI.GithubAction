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

        public async Task<PlaylistMusicasQueryAnomima> BuscarPlaylistComMusicas(Expression<Func<Playlist, bool>> expression)
        {
            //var query = await _context.Playlists
            //    .Where(expression)
            //    .Select(p => new {
            //        p.Id,
            //        p.UsuarioId,
            //        p.Titulo,
            //        p.Descricao,
            //        p.Foto,
            //        Musicas = p.Musicas
            //    .Select(m => new { m.Musica.Id, m.Musica.Nome, m.Musica.Duracao, m.Musica.AlbumId, m.Musica.Album.Titulo })
            //    .AsEnumerable()
            //    }).FirstOrDefaultAsync();

            //var plt = new PlaylistMusicasQueryAnomima(query.Id, query.UsuarioId, query.Titulo, query.Descricao, query.Foto);
            //var musicas = query.Musicas;

            //foreach (var item in musicas)
            //{
            //    var musicaTransporte = new MusicaQueryAnonima
            //    {
            //        Id = item.Id,
            //        Nome = item.Nome,
            //        Duracao = item.Duracao.Formatado,
            //        AlbumId = item.AlbumId,
            //        TituloAlbum = item.Titulo
            //    };
            //    plt.Musicas.Add(musicaTransporte);
            //}

            //return plt;

            var query = await _context.Playlists
                .Where(expression)
                .Select(p => new PlaylistMusicasQueryAnomima
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
                        Duracao = x.Musica.Duracao.Formatado,
                        TituloAlbum = x.Musica.Album.Titulo
                    })
                }).FirstOrDefaultAsync();

            return query;

        }                

        public async Task<IEnumerable<PlaylistMusicasQueryAnomima>> BuscarPlaylistsPorCriterio(Expression<Func<Playlist, bool>> expression)
        {
            var query = await _context.Playlists
                .Where(expression)
                .Select(p => new PlaylistMusicasQueryAnomima 
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
                            Duracao = x.Musica.Duracao.Formatado, 
                            TituloAlbum = x.Musica.Album.Titulo
                        })
                }).ToListAsync();            

            return query;
        }
    } 
    
}
