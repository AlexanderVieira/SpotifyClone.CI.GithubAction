namespace AVS.Core.ObjValor
{
    public class Duracao
    {
        public Duracao(int valor)
        {
            Valor = valor;
        }

        public int Valor { get; set; }

        private string _formatado;
        public string Formatado 
        { 
            get { return _formatado; } 
            set { _formatado = ValorFormatado(); } 
        }
        
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
