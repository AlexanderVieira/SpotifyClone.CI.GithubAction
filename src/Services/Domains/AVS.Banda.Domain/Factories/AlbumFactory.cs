using AVS.Core.ObjDoinio;

namespace AVS.Banda.Domain.Factories
{
    public static class AlbumFactory
    {
        public static Album Criar(string nome, string descricao, Musica musica)
        {
            //if (musica == null) 
            //    throw new DomainException("Para criar um album, o album deve ter no minimo uma musica");
            Validar(musica);
            var album = new Album(nome, descricao);
            album.AdicionarMusica(musica);
            
            return album;           
            
        }

        public static Album Criar(string nome, string descricao, IList<Musica> musicas)
        {
            //if (!musicas.Any())
            //    throw new DomainException("Para criar um album, o album deve ter no minimo uma musica");

            Validar(musicas);
            var album = new Album(nome, descricao);
            album.AtualizarMusicas(musicas);

            return album;

            //return new Album()
            //{
            //    Musicas = musicas.ToList()
            //};

        }

        private static void Validar(Musica musica)
        {
            Validacao.ValidarSeNulo(musica, "Para criar um album, o album deve ter no minimo uma musica");
        }

        private static void Validar(IList<Musica> musicas)
        {            
            var lista = (IList<object>)musicas;
            Validacao.ValidarSeExiste(lista, "Para criar um album, o album deve ter no minimo uma musica");
        }
    }
}
