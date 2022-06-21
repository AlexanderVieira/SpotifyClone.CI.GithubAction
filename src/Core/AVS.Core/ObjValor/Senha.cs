using AVS.Core.ObjDoinio;

namespace AVS.Core.ObjValor
{
    public class Senha
    {
        public string Valor { get; set; }
        
        public Senha(string valor)
        {
            Valor = valor ?? throw new DomainException(Valor);
        }
    }
}
