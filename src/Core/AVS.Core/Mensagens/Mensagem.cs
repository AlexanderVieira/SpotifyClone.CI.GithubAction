namespace AVS.Core.Mensagens
{
    public abstract class Mensagem
    {
        public string TipoMensagem { get; set; }
        public Guid AggregateRootId { get; set; }

        public Mensagem()
        {
            TipoMensagem = GetType().Name;
        }
    }
}
