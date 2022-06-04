using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVS.Banda.Domain
{
    public class Album
    {        
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public IList<Musica> Musicas { get; set; }
    }
}
