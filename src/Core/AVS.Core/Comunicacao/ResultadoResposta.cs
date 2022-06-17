namespace AVS.Core.Comunicacao
{
    public class ResultadoResposta
    {
        public string Titulo { get; set; }
        public int Codigo { get; set; }
        public RespostaMensagemErros Erros { get; set; }
        public ResultadoResposta()
        {
            Erros = new RespostaMensagemErros();
        }


    }

    public class RespostaMensagemErros
    {
        public List<string> Mensagens { get; set; }

        public RespostaMensagemErros()
        {
            Mensagens = new List<string>();
        }
    }
}
