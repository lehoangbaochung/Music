using Music.Extensions;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Website.Models
{
    public class PlaylistViewModel
    {
        public class Audio
        {
            public Audio(string id, bool shuffle = false)
            {
                if (id != null)
                {
                    if (!shuffle)
                    {
                        Songs = DataExtension.GetSongs(id);
                    }   
                    else
                    {
                        Random random = new();
                        Songs = DataExtension.GetSongs(id)
                            .OrderBy(s => random.Next()).ToList();
                    }    
                }    
            }

            public string Id => Songs.GetEmbedId();

            public List<Song> Songs { get; } = new();

            public List<Album> Albums => Songs.GetAlbums();

            public List<Artist> Artists => Songs.GetArtists();

            public List<Video> Videos => Songs.GetVideos();
        }
    }
}