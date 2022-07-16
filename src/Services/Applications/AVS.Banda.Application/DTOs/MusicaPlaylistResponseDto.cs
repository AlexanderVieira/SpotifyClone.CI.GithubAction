namespace AVS.Banda.Application.DTOs
{
    //public record MusicaPlaylistResponseDto(Guid PlaylistId, Guid MusicaId, PlaylistResponseDto Playlist, MusicaResponseDto Musica);
        
    public class MusicaPlaylistResponseDto
    {
        public Guid MusicaId { get; set; }
        public Guid PlaylistId { get; set; }                
                
        //public MusicaResponseDto Musica { get; set; }
                
        //public PlaylistResponseDto Playlist { get; set; }

        public MusicaPlaylistResponseDto()
        {            
        }

    }
}
