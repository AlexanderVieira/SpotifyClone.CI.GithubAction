using AutoMapper;
using AVS.Banda.Application.AppServices;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AVS.Cadastro.Domain.Testes
{
    [Collection(nameof(UsuarioCollection))]
    public class BandaAppServiceTests
    {
        private readonly UsuarioTestsFixture _usuarioTestsFixture;

        public BandaAppServiceTests(UsuarioTestsFixture usuarioTestsFixture)
        {
            _usuarioTestsFixture = usuarioTestsFixture;
        }

        [Fact(DisplayName = "Adicionar Banda com Sucesso")]
        [Trait("Categoria", "Banda AppService Mock Tests")]
        public async Task BandaAppService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange            
            var banda = new Banda.Domain.Entities.Banda(Guid.NewGuid(), "Biquini Cavadao", "Sucesso!", "http://url.com.br");
            var musica = new Musica(Guid.NewGuid(), Guid.NewGuid(), "Vento. Ventania", 300);            
            var musicas = new List<Musica>();
            musicas.Add(musica);
            banda.CriarAlbum(
                Guid.NewGuid(), Guid.NewGuid(), "Top 10", "As dez melhores!", "http://url.com.br", musicas);
            var request = new BandaRequestDto(banda.Id, banda.Nome, banda.Descricao, banda.Foto);
            var bandaService = new Mock<IBandaService>();
            var automapper = new Mock<IMapper>();
            var bandaAppService = new BandaAppService(bandaService.Object, automapper.Object);
            automapper.Setup(x => x.Map<Banda.Domain.Entities.Banda>(request)).Returns(banda);

            //Act
            await bandaAppService.Salvar(request);

            //Asset            
            bandaService.Verify(r => r.Salvar(banda), Times.Once());
        }

        [Fact(DisplayName = "Atualizar Banda com Sucesso")]
        [Trait("Categoria", "Banda AppService Mock Tests")]
        public async Task BandaAppService_Atualizar_DeveExecutarComSucesso()
        {
            //Arrange
            var banda = new Banda.Domain.Entities.Banda(Guid.NewGuid(), "Biquini Cavadao", "Sucesso!", "http://url.com.br");
            var musica = new Musica(Guid.NewGuid(), Guid.NewGuid(), "Vento. Ventania", 300);
            var musicas = new List<Musica>();
            musicas.Add(musica);
            banda.CriarAlbum(
                Guid.NewGuid(), Guid.NewGuid(), "Top 10", "As dez melhores!", "http://url.com.br", musicas);
            var request = new BandaRequestDto(banda.Id, banda.Nome, banda.Descricao, banda.Foto);
            var bandaService = new Mock<IBandaService>();
            var automapper = new Mock<IMapper>();
            var bandaAppService = new BandaAppService(bandaService.Object, automapper.Object);
            automapper.Setup(x => x.Map<Banda.Domain.Entities.Banda>(request)).Returns(banda);

            //Act
            await bandaAppService.Atualizar(request);

            //Asset            
            bandaService.Verify(r => r.Atualizar(banda), Times.Once());
        }

        [Fact(DisplayName = "Remover Banda com Sucesso")]
        [Trait("Categoria", "Banda AppService Mock Tests")]
        public async Task BandaAppService_Remover_DeveExecutarComSucesso()
        {
            //Arrange
            var banda = new Banda.Domain.Entities.Banda(Guid.NewGuid(), "Biquini Cavadao", "Sucesso!", "http://url.com.br");
            var musica = new Musica(Guid.NewGuid(), Guid.NewGuid(), "Vento. Ventania", 300);
            var musicas = new List<Musica>();
            musicas.Add(musica);
            banda.CriarAlbum(
                Guid.NewGuid(), Guid.NewGuid(), "Top 10", "As dez melhores!", "http://url.com.br", musicas);
            var request = new BandaRequestDto(banda.Id, banda.Nome, banda.Descricao, banda.Foto);
            var bandaService = new Mock<IBandaService>();
            var automapper = new Mock<IMapper>();
            var bandaAppService = new BandaAppService(bandaService.Object, automapper.Object);
            automapper.Setup(x => x.Map<Banda.Domain.Entities.Banda>(request)).Returns(banda);

            //Act
            await bandaAppService.Exluir(request);

            //Asset            
            bandaService.Verify(r => r.Exluir(banda), Times.Once());
        }        
    }        
}
