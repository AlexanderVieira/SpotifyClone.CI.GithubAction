namespace AVS.Core.ObjValor
{
    public class Duracao
    {
        public Duracao(int valor)
        {
            Valor = valor;
            Formatado = ValorFormatado();
        }

        public int Valor { get; set; }
        public string Formatado { get; private set; }

        //private string _formatado;        

        //public string Formatado
        //{
        //    get { return _formatado; }
        //    private set { _formatado = value; }
        //}

        //public string Formatado => ValorFormatado();

        private string ValorFormatado()
        {
            //var horas = Convert.ToDecimal(Valor) / 3600;
            var horas = Math.Floor(Convert.ToDecimal(Valor) / 3600);
            var duracao = horas % 3600;

            var minutos = Math.Floor(Convert.ToDecimal(Valor) / 60);
            //var minutos = duracao / 60;
            var segundos = duracao % 60;
             
            if (horas > 0)
            {
                return $"{horas.ToString().PadLeft(2, '0')} : {minutos.ToString().PadLeft(2, '0')} : {segundos.ToString().PadLeft(2, '0')}";
            }

            return $"{minutos.ToString().PadLeft(2, '0')} Min : {segundos.ToString().PadLeft(2, '0')} Seg";
        }
    }
}
