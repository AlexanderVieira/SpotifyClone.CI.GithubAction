using AVS.Core.Comunicacao;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AVS.Documentacao.API.Controllers
{
    [ApiController]
    public abstract class PrincipalController : Controller
    {
        protected ICollection<string> Erros = new List<string>();
        protected ValidationResult ValidationResult { get; set; }

        protected Guid UsuarioId = Guid.Parse("b1fcba9a-819c-4dc0-a542-24f96f8460eb");
        protected string MensagemSucesso { get; set; }

        protected virtual bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            throw new NotImplementedException();
        }

        protected virtual bool EhValido(object obj)
        {
            throw new NotImplementedException();
        }
        protected ActionResult RespostaPersonalizada(object? resultado = null)
        {
            if (OperacaoValida()) 
            {
                if(resultado is int) return TratarMensagensRetorno(resultado);
                return Ok(resultado);
            } 
            
            if (resultado is int) return TratarMensagensRetorno(resultado);

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

        protected ActionResult ProcessarRespostaMensagem(int statusCode, string mensagem)
        {
            AdicionarErroProcessamento(mensagem);
            return RespostaPersonalizada(statusCode);
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

        protected void AdicionaMensagemSucesso(string mensagem)
        {
            MensagemSucesso = mensagem;
        }

        protected void LimparErrosProcessamento()
        {
            Erros.Clear();
        }
        private ActionResult TratarMensagensRetorno(object resultado)
        {
            switch (resultado)
            {
                case 200:
                    return Ok(new
                    {
                        Titulo = "Opa! Sucesso.",
                        Codigo = StatusCodes.Status200OK,
                        Sucesso = MensagemSucesso
                    });

                case 201:
                    return Ok(new
                    {
                        Titulo = "Opa! Sucesso.",
                        Codigo = StatusCodes.Status201Created,
                        Sucesso = MensagemSucesso
                    });

                case 204:
                    return Ok(new
                    {
                        Titulo = "Opa! Sucesso.",
                        Codigo = StatusCodes.Status204NoContent,
                        Sucesso = MensagemSucesso
                    });

                case 400:
                    return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                        {
                            { "Mensagens", Erros.ToArray() }
                        }));

                case 401:
                    return Unauthorized(new ValidationProblemDetails(new Dictionary<string, string[]>
                        {
                            { "Mensagens", Erros.ToArray() }
                        }));

                case 404:
                    return NotFound(new ResultadoResposta
                    {
                        Titulo = "Opa! Ocorreu um erro.",
                        Codigo = StatusCodes.Status404NotFound,
                        Erros = new RespostaMensagemErros { Mensagens = Erros.ToList() }
                    });

                default:
                    return BadRequest(new
                    {
                        Titulo = "Opa! Ocorreu um erro.",
                        Codigo = StatusCodes.Status500InternalServerError,
                        Mensagem = "Sistema indisponível. Tente mais tarde."
                    });
            }

        }

    }
}
