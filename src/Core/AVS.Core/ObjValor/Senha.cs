using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVS.Core.ObjValor
{
    public class Senha
    {
        public string Valor { get; set; }
        public Senha()
        {
        }

        public Senha(string valor)
        {
            this.Valor = valor ?? throw new ArgumentException(this.Valor);
        }
    }
}
