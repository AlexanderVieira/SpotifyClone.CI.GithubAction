namespace AVS.Banda.Domain.AppServices.DTOs
{
    public class MusicaPlaylistDTO
    {        
        public Guid PlaylistId { get; set; }
        public Guid MusicaId { get; set; }
        public PlaylistDTO Playlist { get; set; }
        public MusicaDTO Musica { get; set; }

        //public MusicaPlaylistDTO(Guid playlistId, Guid musicaId)
        //{
        //    PlaylistId = playlistId;
        //    MusicaId = musicaId;
        //}
    }
}
