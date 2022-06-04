using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVS.Banda.Domain.Factories
{
    public static class AlbumFactory
    {
        public static Album Criar(string nome, Musica musica)
        {
            if (musica == null)
            {
                throw new ArgumentException("Para criar um album, o album deve ter no minimo uma musica");
            }

            return new Album()
            {
                Musicas = new List<Musica>() { musica }
            };
        }

        public static Album Criar(string nome, IEnumerable<Musica> musicas)
        {
            if (!musicas.Any())
                throw new ArgumentNullException("Para criar um album, o album deve ter no minimo uma musica");

            return new Album()
            {
                Musicas = musicas.ToList()
            };

        }
    }
}
