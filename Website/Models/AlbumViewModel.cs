using Music.Extensions;
using Music.Models;
using System.Collections.Generic;

namespace Website.Models
{
    public static class AlbumViewModel 
    {
        public class Detail
        {
            public Detail(Album album)
            {
                Album = album;
            }

            public Album Album { get; }

            public List<Album> RelatedAlbums => Album.GetRelatedAlbums();

            public List<Song> Songs => Album.GetSongs();

            public List<Artist> Artists => Album.GetArtists();

            public List<Video> Videos => Album.GetVideos();

            public ModalViewModel SongModal
                => new() { Id = Album.Id, Title = $"Bài hát ({Songs.Count})", Items = Songs };

            public ModalViewModel ArtistModal
                => new() { Id = Album.Id, Title = $"Ca sĩ ({Artists.Count})", Items = Artists };

            public ModalViewModel VideoModal
                => new() { Id = Album.Id, Title = $"Video ({Videos.Count})", Items = Videos };

            public ModalViewModel RelatedModal
                => new() { Id = Album.Id, Title = $"Đề xuất ({RelatedAlbums.Count})", Items = RelatedAlbums };
        }
    }
}
