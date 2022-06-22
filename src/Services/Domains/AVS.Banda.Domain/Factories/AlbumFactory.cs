using AVS.Banda.Domain.Entities;
using AVS.Core.ObjDoinio;

namespace AVS.Banda.Domain.Factories
{
    public static class AlbumFactory
    {
        public static Album Criar(Guid id, string nome, string descricao, string foto, Musica musica)
        {            
            Validar(musica);
            var album = new Album(id, nome, descricao, foto);
            album.AdicionarMusica(musica);
            
            return album;
        }

        public static Album Criar(Guid id, string nome, string descricao, string foto, IList<Musica> musicas)
        {
            Validar(musicas);
            var album = new Album(id, nome, descricao, foto);
            album.AtualizarMusicas(musicas);

            return album;
        }

        private static void Validar(Musica musica)
        {
            Validacao.ValidarSeNulo(musica, "Para criar um album, o album deve ter no minimo uma musica");
        }

        private static void Validar(IList<Musica> musicas)
        {            
            var lista = musicas.Cast<object>().ToList(); ;
            Validacao.ValidarSeExiste(lista, "Para criar um album, o album deve ter no minimo uma musica");
        }
    }
}
