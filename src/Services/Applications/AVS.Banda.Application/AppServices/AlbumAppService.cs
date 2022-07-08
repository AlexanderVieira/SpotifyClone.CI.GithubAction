using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Application.AppServices
{
    public class AlbumAppService : IAlbumAppService
    {
        private readonly IAlbumService _albumService;

        public AlbumAppService(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public Task<AlbumResponseDto> BuscarPorCriterio(Expression<Func<AlbumRequestDto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<AlbumResponseDto> BuscarPorCriterio(Expression<Func<Album, bool>> expression)
        {
            var album = await _albumService.BuscarPorCriterio(expression);
            if (album == null) return null;
            var albumDTO = AlbumDTO.ConverterParaAlbumDTO(album);
            return null;
        }

        public Task<IEnumerable<AlbumResponseDto>> BuscarTodosPorCriterio(Expression<Func<AlbumRequestDto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AlbumResponseDto>> BuscarTodosPorCriterio(Expression<Func<Album, bool>> expression)
        {
            var albuns = await _albumService.BuscarTodosPorCriterio(expression);
            if (albuns == null) return null;
            return null;
            //return albuns.Select(AlbumDTO.ConverterParaAlbumDTO);
        }

        public async Task<IEnumerable<AlbumResponseDto>> ObterTodos()
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
            return null;
            //return albuns.Select(AlbumDTO.ConverterParaAlbumDTO);
        }

        public async Task<AlbumResponseDto> ObterPorId(object id)
        {
            var album = await _albumService.ObterPorId(id);
            if (album == null) return null;
            var albumDTO = AlbumDTO.ConverterParaAlbumDTO(album);
            return null;
        }

        public async Task Salvar(AlbumRequestDto request)
        {
            //var album = AlbumDTO.ConverterParaAlbum(request);
            //album.Validar();
            //await _albumService.Salvar(album);
        }

        public async Task Atualizar(AlbumRequestDto request)
        {
            //var album = AlbumDTO.ConverterParaAlbum(request);
            //album.Validar();
            //await _albumService.Atualizar(album);
        }

        public async Task Exluir(AlbumRequestDto request)
        {
            //var album = AlbumDTO.ConverterParaAlbum(request);
            //album.Validar();
            //await _albumService.Exluir(album);
        }

    }

}
