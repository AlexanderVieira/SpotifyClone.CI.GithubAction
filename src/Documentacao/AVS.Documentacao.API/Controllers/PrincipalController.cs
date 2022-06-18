using AVS.Core.Comunicacao;
using AVS.Core.Data;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AVS.Documentacao.API.Controllers
{
    [ApiController]
    public abstract class PrincipalController : Controller
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult RespostaPersonalizada(object? resultado = null)
        {
            if (OperacaoValida()) return Ok(resultado);
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]> 
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }

        protected ActionResult RespostaPersonalizada(ModelStateDictionary modelState)
        {
            var modelErrorCollection = modelState.Values.Select(x => x.Errors);
            foreach (var modelErrors in modelErrorCollection)
            {
                foreach (var modelError in modelErrors)
                {
                    AdicionarErroProcessamento(modelError.ErrorMessage);
                }                
            }
            return RespostaPersonalizada();
        }

        protected ActionResult RespostaPersonalizada(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }
            return RespostaPersonalizada();
        }

        protected ActionResult RespostaPersonalizada(ResultadoResposta resposta)
        {            
            RespostaPossuiErros(resposta);
            return RespostaPersonalizada();
        }

        protected bool RespostaPossuiErros(ResultadoResposta resposta)
        {
            if (resposta == null || !resposta.Erros.Mensagens.Any()) return false;
            foreach (var mensagem in resposta.Erros.Mensagens)
            {
                AdicionarErroProcessamento(mensagem);
            }
            return true;
        }

        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }

        protected void AdicionarErroProcessamento(string mensagem)
        {
            Erros.Add(mensagem);
        }

        protected void LimparErrosProcessamento()
        {
            Erros.Clear();
        }        
    }
}
