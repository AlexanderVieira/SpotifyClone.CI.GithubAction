namespace AVS.Banda.Domain.Entities
{
    public class MusicaPlaylist
    {
        public Guid PlaylistId { get; set; }
        public Guid MusicaId { get; set; }
        public virtual Playlist Playlist { get; set; }
        public virtual Musica Musica { get; set; }

        //public MusicaPlaylist(Guid playlistId, Guid musicaId)
        //{            
        //    PlaylistId = playlistId;
        //    MusicaId = musicaId;
        //}
    }
}
