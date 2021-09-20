using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Extensions
{
    public static class DataHelper
    {
        private const char JOIN_CHARACTER = '-';
        private const string SPLIT_CHARACTER = "/";

        private static readonly Random random = new();

        private static readonly char[] aChars = { 'A', 'Á', 'À', 'Ă', 'Â', 'Á' };
        private static readonly char[] dChars = { 'D', 'Đ' };
        private static readonly char[] eChars = { 'E', 'Ê' };
        private static readonly char[] oChars = { 'O', 'Ô', 'Ơ' };
        private static readonly char[] uChars = { 'U', 'Ư' };
        private static readonly char[] numberChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        //public static IList<Artist> Where(List<Artist> sourceList, char character)
        //{
        //    List<Artist> outterList = new();

        //    if (char.IsLower(character))
        //    {
        //        character = char.ToUpper(character);
        //    }

        //    if (character.Equals('/'))
        //    {
        //        outterList = sourceList.OrderBy(artist => artist.VietnameseName).ToList();
        //    }
        //    else if (character.Equals('#'))
        //    {
        //        foreach (var numberChar in numberChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(numberChar)));
        //        }
        //    }
        //    else if (aChars.Contains(character))
        //    {
        //        foreach (var aChar in aChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(aChar)));
        //        }
        //    }
        //    else if (dChars.Contains(character))
        //    {
        //        foreach (var dChar in dChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(dChar)));
        //        }
        //    }
        //    else if (eChars.Contains(character))
        //    {
        //        foreach (var eChar in eChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(eChar)));
        //        }
        //    }
        //    else if (oChars.Contains(character))
        //    {
        //        foreach (var oChar in oChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(oChar)));
        //        }
        //    }
        //    else if (uChars.Contains(character))
        //    {
        //        foreach (var uChar in uChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(uChar)));
        //        }
        //    }
        //    else
        //    {
        //        outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(character)));
        //    }

        //    return outterList;
        //}

        //public static IList<Base> Where(List<Base> sourceList, char character)
        //{
        //    List<Base> outterList = new();

        //    if (char.IsLower(character))
        //    {
        //        character = char.ToUpper(character);
        //    }

        //    if (character.Equals('/'))
        //    {
        //        outterList = sourceList.OrderBy(artist => artist.VietnameseName).ToList();
        //    }
        //    else if (character.Equals('#'))
        //    {
        //        foreach (var numberChar in numberChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(numberChar)));
        //        }
        //    }
        //    else if (aChars.Contains(character))
        //    {
        //        foreach (var aChar in aChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(aChar)));
        //        }
        //    }
        //    else if (dChars.Contains(character))
        //    {
        //        foreach (var dChar in dChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(dChar)));
        //        }
        //    }
        //    else if (eChars.Contains(character))
        //    {
        //        foreach (var eChar in eChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(eChar)));
        //        }
        //    }
        //    else if (oChars.Contains(character))
        //    {
        //        foreach (var oChar in oChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(oChar)));
        //        }
        //    }
        //    else if (uChars.Contains(character))
        //    {
        //        foreach (var uChar in uChars)
        //        {
        //            outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(uChar)));
        //        }
        //    }
        //    else
        //    {
        //        outterList.AddRange(sourceList
        //                .Where(a => a.VietnameseName.ToUpper().StartsWith(character)));
        //    }

        //    return outterList;
        //}

        //public static string GetNames(in string id, string splitCharacter = SPLIT_CHARACTER, 
        //    Language language = default)
        //{
        //    var artistName = string.Empty;

        //    foreach (var artistId in id.Split(JOIN_CHARACTER))
        //    {
        //        var artist = DataProvider.Artists.Find(a => a.Id.Equals(artistId));
        //        if (artist == null)
        //        {
        //            throw new NullReferenceException("Name is not found");
        //        }
        //        else
        //        {
        //            artistName += language switch
        //            {
        //                Language.English => artist.PinyinName + splitCharacter,
        //                Language.SimplifiedChinese => artist.SimplifiedChineseName + splitCharacter,
        //                Language.TraditionalChinese => artist.TraditionalChineseName + splitCharacter,
        //                _ => artist.VietnameseName + splitCharacter,
        //            };
        //        }
        //    }
        //    return artistName.Remove(artistName.LastIndexOf(splitCharacter)).TrimEnd();
        //}

        public static List<Song> GetRelatedSongs(this Song song)
        {
            List<Song> songs = new();
            // Find the songs in the same album
            foreach (var album in song.GetAlbums())
            {
                foreach (var relatedSong in album.GetSongs())
                {
                    if (!relatedSong.Equals(song)
                        && !songs.Contains(relatedSong))
                    {
                        songs.Add(relatedSong);
                    }    
                }    
            }    
            // Find the songs in the same artist
            foreach (var artist in song.GetArtists())
            {
                foreach (var relatedSong in artist.GetSongs())
                {
                    if (!relatedSong.Equals(song)
                        && !songs.Contains(relatedSong))
                    {
                        songs.Add(relatedSong);
                    }
                }
            }
            return songs.Count == 0 ?
                DataProvider.Songs.OrderBy(relatedSong => random.Next()).ToList() :
                songs.OrderBy(relatedSong => random.Next()).ToList();
        }

        /// <summary>
        /// Get the remain albums of artists in this album
        /// </summary>
        /// <param name="album"></param>
        /// <returns>An album list related to this album</returns>
        public static List<Album> GetRelatedAlbums(this Album album)
        {
            List<Album> albums = new();
            foreach (var artist in album.GetArtists())
            {
                foreach (var relatedAlbum in artist.GetAlbums())
                {
                    if (!relatedAlbum.Equals(album) 
                        && !albums.Contains(relatedAlbum))
                    {
                        albums.Add(relatedAlbum);
                    }    
                }    
            }       
            return albums.Count == 0 ? 
                DataProvider.Albums.OrderBy(relatedAlbum => random.Next()).ToList() :
                albums.OrderBy(relatedAlbum => random.Next()).ToList();
        }

        public static List<Artist> GetRelatedArtists(this Artist artist)
        {
            List<Artist> artists = new();
            foreach (var song in artist.GetSongs())
            {
                foreach (var relatedArtist in song.GetArtists())
                {
                    if (!relatedArtist.Equals(artist)
                        && !artists.Contains(relatedArtist))
                    {
                        artists.Add(relatedArtist);
                    }    
                }    
            }    
            return artists.Count == 0 ?
                DataProvider.Artists.OrderBy(relatedArtist => random.Next()).ToList() :
                artists.OrderBy(relatedArtist => random.Next()).ToList();
        }

        public static List<Album> GetAlbums(this List<Song> songs)
        {
            List<Album> albums = new();
            foreach (var song in songs)
            {
                foreach (var album in song.GetAlbums())
                {
                    if (!albums.Contains(album))
                    {
                        albums.Add(album);
                    }
                }
            }
            return albums;
        }

        public static List<Artist> GetArtists(this List<Song> songs)
        {
            List<Artist> artists = new();
            foreach (var song in songs)
            {
                foreach (var artist in song.GetArtists())
                {
                    if (!artists.Contains(artist))
                    {
                        artists.Add(artist);
                    }    
                }    
            }    
            return artists;
        }

        public static List<Video> GetVideos(this List<Song> songs)
        {
            List<Video> videos = new();
            foreach (var song in songs)
            {
                foreach (var video in song.GetVideos())
                {
                    if (!videos.Contains(video))
                    {
                        videos.Add(video);
                    }    
                }    
            }    
            return videos;
        }

        public static string GetSongIds(this List<Song> songs)
        {
            var songIds = string.Empty;
            songs.ForEach(song => songIds += song.Id + ',');
            return songIds.Remove(songIds.Length - 1);
        }

        public static string GetEmbedId(this List<Song> songs)
        {
            return songs.Count == 0 ? null :
                $"{songs[0].Id}?playlist={songs.GetSongIds()}";
        }

        public static List<Song> GetSongs(string[] songIds)
        {
            List<Song> songs = new();
            foreach (var songId in songIds)
            {
                var song = DataProvider.Songs
                    .Find(s => s.Id.Equals(songId));
                if (song == null)
                {
                    throw new NullReferenceException(
                        "Not found the song with id " + songId);
                }
                songs.Add(song);
            }
            return songs;
        }
    }
}
