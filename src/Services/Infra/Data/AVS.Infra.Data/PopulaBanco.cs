using AVS.Banda.Domain.Entities;
using AVS.Cadastro.Domain.Entities;

namespace AVS.Infra.Data
{
    public class PopulaBanco
    {        
        public static async void Popular(SpotifyCloneContext _context)
        {
            ArgumentNullException.ThrowIfNull(_context, nameof(_context));
            _context.Database.EnsureCreated();

            if (!_context.Usuarios.Any())
            {
                var usuarios = new List<Usuario>()
                {
                    new Usuario(
                        Guid.Parse("b1fcba9a-819c-4dc0-a542-24f96f8460eb"),
                        "Alexander",
                        "alex@teste.com",
                        "19100000000",
                        "http://url.com",
                        true),
                    new Usuario(
                        Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff1"),
                        "Novo Usuario 1",
                        "novousuario1@teste.com",
                        "19100000000",
                        "http://url.com",
                        true),
                    new Usuario(
                        Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff2"),
                        "Novo Usuario 2",
                        "novousuario2@teste.com",
                        "19100000000",
                        "http://url.com",
                        false),
                    new Usuario(
                        Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff3"),
                        "Novo Usuario 3",
                        "novousuario3@teste.com",
                        "19100000000",
                        "http://url.com",
                        true)
                };

                await _context.Usuarios.AddRangeAsync(usuarios);
                await _context.SaveChangesAsync();
            }

            if (!_context.Playlists.Any())
            {
                var playlists = new List<Playlist>()
                {
                    new Playlist(
                        Guid.Parse("077abae9-c0c6-46f7-986a-b2968d65de98"), 
                        Guid.Parse("b1fcba9a-819c-4dc0-a542-24f96f8460eb"),
                        "Minha Playlist nº1",
                        "Preencha sua descrição",
                        "http://uri.com.br"),
                    new Playlist(
                        Guid.Parse("c784fad9-9a85-4110-9fa6-1f99b495a684"), 
                        Guid.Parse("b1fcba9a-819c-4dc0-a542-24f96f8460eb"),
                        "Minha Playlist nº2",
                        "Preencha sua descrição",
                        "http://uri.com.br"),
                    new Playlist(
                        Guid.Parse("b7b1f934-2302-4437-bdb9-86040702b417"), 
                        Guid.Parse("b1fcba9a-819c-4dc0-a542-24f96f8460eb"),
                        "Minha Playlist nº3",
                        "Preencha sua descrição",
                        "http://uri.com.br")
                };

                await _context.Playlists.AddRangeAsync(playlists);
                await _context.SaveChangesAsync();

            }

            if (!_context.Bandas.Any())
            {
                var m1 = new List<Musica>()
                {
                    new Musica(Guid.Parse("682068cf-c21e-4a36-b843-63b9d181f1bf"),
                               Guid.Parse("e190530d-667e-42f1-9bb3-c69a117244de"),
                               "Vento Ventania", 300)
                };                
                
                var m2 = new List<Musica>() 
                {
                    new Musica(Guid.Parse("682068cf-c21e-4a36-b843-63b9d181f1bf"),
                               Guid.Parse("e190530d-667e-42f1-9bb3-c69a117244dd"),
                               "Vento Ventania", 600),
                    new Musica(Guid.Parse("682068cf-c21e-4a36-b843-63b9d181f1cf"),
                               Guid.Parse("e190530d-667e-42f1-9bb3-c69a117244dd"),
                               "Você Não Soube Me Amar", 300)
                };
                

                var b1 = new Banda.Domain.Entities.Banda(
                            Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa1"), 
                            "Biquini Cavadão", 
                            "http://myurl.com", 
                            "Artista verificado");
                
                b1.CriarAlbum(
                    Guid.Parse("e190530d-667e-42f1-9bb3-c69a117244dd"),
                    Guid.Parse("cee1c9d0-84c6-4f45-8408-a756211e1c32"),
                    "A Dois Passos do Paraíso",
                    "Ano: 2010",
                    "http://myurl.com", m1);

                var b2 = new Banda.Domain.Entities.Banda(
                            Guid.Parse("cee1c9d0-84c6-4f45-8408-a756211e1c32"),
                            "Blitz",
                            "http://myurl.com",
                            "Artista verificado");

                b2.CriarAlbum(
                    Guid.Parse("e190530d-667e-42f1-9bb3-c69a117244dd"),
                    Guid.Parse("cee1c9d0-84c6-4f45-8408-a756211e1c32"),
                    "A Dois Passos do Paraíso",
                    "Ano: 2010",
                    "http://myurl.com", m2);

                var bandas = new List<Banda.Domain.Entities.Banda>()
                {                    
                    new Banda.Domain.Entities.Banda(
                        Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa2"),
                        "Legião Urbana",
                        "http://myurl.com",
                        "Artista verificado"),
                    new Banda.Domain.Entities.Banda(
                        Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa3"),
                        "Nenhum De Nós","http://myurl.com",
                        "Artista verificado"),
                    new Banda.Domain.Entities.Banda(
                        Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa4"),
                        "Engenheiros do Hawaii",
                        "http://myurl.com",
                        "Artista verificado")                    
                };

                bandas.Add(b1);
                bandas.Add(b2);

                await _context.AddRangeAsync(bandas);
                await _context.SaveChangesAsync();
            }

            if (!_context.MusicaPlaylists.Any())
            {
                var associacoes = new List<MusicaPlaylist>()
                {
                    new MusicaPlaylist 
                    {
                        MusicaId = Guid.Parse("682068cf-c21e-4a36-b843-63b9d181f1bf"),
                        PlaylistId = Guid.Parse("c784fad9-9a85-4110-9fa6-1f99b495a684")
                    },
                    new MusicaPlaylist
                    {
                        MusicaId = Guid.Parse("682068cf-c21e-4a36-b843-63b9d181f1bf"),
                        PlaylistId = Guid.Parse("077abae9-c0c6-46f7-986a-b2968d65de98")
                    }
                };

                await _context.AddRangeAsync(associacoes);
                await _context.SaveChangesAsync();
            }
        }
    }
}
