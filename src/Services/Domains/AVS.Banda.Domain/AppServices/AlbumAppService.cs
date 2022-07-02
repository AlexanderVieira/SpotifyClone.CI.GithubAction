using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.AppServices;
using AVS.Banda.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.AppServices
{
    public class AlbumAppService : IAlbumAppService
    {
        private readonly IAlbumService _albumService;

        public AlbumAppService(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public Task<AlbumDTO> BuscarPorCriterio(Expression<Func<AlbumDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<AlbumDTO> BuscarPorCriterio(Expression<Func<Album, bool>> expression)
        {
            var album = await _albumService.BuscarPorCriterio(expression);            
            if (album == null) return null;
            var albumDTO = AlbumDTO.ConverterParaAlbumDTO(album);
            return albumDTO;
        }
        
        public Task<IEnumerable<AlbumDTO>> BuscarTodosPorCriterio(Expression<Func<AlbumDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AlbumDTO>> BuscarTodosPorCriterio(Expression<Func<Album, bool>> expression)
        {
            var albuns = await _albumService.BuscarTodosPorCriterio(expression);
            if (albuns == null) return null;
            return albuns.Select(AlbumDTO.ConverterParaAlbumDTO);
        }

        public async Task<IEnumerable<AlbumDTO>> ObterTodos()
        {
            var albuns = await _albumService.ObterTodos();
            //Validacao.ValidarSeNulo(bandas.Cast<object>().ToList(), "Não existem dados para exibição.");
            if (albuns == null) return null;
            //IEnumerable<AlbumDTO> albumDTOs = new List<AlbumDTO>();
            //foreach (var album in albuns)
            //{
            //    var albumDTO = AlbumDTO.ConverterParaAlbumDTO(album);
            //    albumDTOs = albumDTOs.Append(albumDTO);
            //}
            //return albumDTOs;
            return albuns.Select(AlbumDTO.ConverterParaAlbumDTO);
        }

        public async Task<AlbumDTO> ObterPorId(object id)
        {
            var album = await _albumService.ObterPorId(id);            
            if (album == null) return null;
            var albumDTO = AlbumDTO.ConverterParaAlbumDTO(album);
            return albumDTO;
        }

        public async Task Salvar(AlbumDTO entity)
        {
            var album = AlbumDTO.ConverterParaAlbum(entity);
            album.Validar();
            await _albumService.Salvar(album);
        }

        public async Task Atualizar(AlbumDTO entity)
        {
            var album = AlbumDTO.ConverterParaAlbum(entity);
            album.Validar();
            await _albumService.Atualizar(album);
        }
        
        public async Task Exluir(AlbumDTO entity)
        {
            var album = AlbumDTO.ConverterParaAlbum(entity);
            album.Validar();
            await _albumService.Exluir(album);
        }
        
    }
    
}
