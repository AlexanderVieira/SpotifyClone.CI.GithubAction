using AVS.Banda.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVS.Banda.Domain
{
    public class Banda
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public IList<Album> Albuns { get; set; }

        public void CriarAlbum(string nome, IList<Musica> musicas)
        {
            var album = AlbumFactory.Criar(nome, musicas);
            this.Albuns.Add(album);           
        }

        public int QuantidadeAlbuns() => this.Albuns.Count;

        public IEnumerable<Musica> ObterMusicas () => this.Albuns.SelectMany(x => x.Musicas).AsEnumerable();
    }
}
