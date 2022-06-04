using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVS.Core.ObjValor
{
    public class Duracao
    {
        public Duracao()
        {

        }

        public int Valor { get; set; }
        public string Formatado => ValorFormatado();

        private string ValorFormatado()
        {
            var horas = Math.Floor(Convert.ToDecimal(this.Valor) / 3600);
            var duracao = horas % 3600;

            var minutos = Math.Floor(duracao / 60);
            var segundos = duracao % 60;

            if (horas > 0)
            {
                return $"{horas.ToString().PadLeft(2, '0')} : {minutos.ToString().PadLeft(2, '0')} : {segundos.ToString().PadLeft(2, '0')}";
            }

            return $"{minutos.ToString().PadLeft(2, '0')} Min : {segundos.ToString().PadLeft(2, '0')} Seg";
        }
    }
}
