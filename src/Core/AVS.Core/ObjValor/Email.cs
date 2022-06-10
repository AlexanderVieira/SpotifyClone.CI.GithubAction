using AVS.Core.ObjDoinio;
using System.Text.RegularExpressions;

namespace AVS.Core.ObjValor
{
    public class Email
    {
        public const int ADDRESS_MAX_LENGTH = 254;
        public const int ADDRESS_MIN_LENGTH = 5;
        public string Address { get; private set; }
                
        public Email(string address)
        {
            Validar(address);
            if (!ValidarEmail(address)) throw new DomainException("Email inválido");
            Address = address;
        }

        private static void Validar(string address)
        {
            Validacao.ValidarSeNuloVazio(address, "E-mail é obrigatório.");
        }

        public static bool ValidarEmail(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
