using MediatR;

namespace AVS.Core.Mensagens
{
    public abstract class Query
    {
        public DateTime Timestamp { get; set; }

        protected Query()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
