using AVS.Core.ObjDoinio;

namespace AVS.Core.ObjValor
{
    public class Senha
    {
        public string Valor { get; private set; }
        
        public Senha(string valor)
        {            
            Valor = valor ?? throw new DomainException("A senha deve ser informada.");
        }
    }
}
