using Music.Interfaces;
using Music.Utilies;
using System;

namespace Music.Models
{
    public class Song : Base, ILyric
    {
        public new int Id { get; set; }

        public string ArtistId { get; set; }

        public string VietnameseLyric { get; set; }

        public string PinyinLyric { get; set; }

        public string SimplifiedChineseLyric { get; set; }

        public string TraditionalChineseLyric { get; set; }

        public string Genre { get; set; }

        public string GetArtistName(string splitCharacter = "/")
        {
            var artistName = string.Empty;
            foreach (var artistId in ArtistId.Split('-'))
            {
                var artist = DataProvider.Artists.Find(a => a.Id.Equals(artistId));

                if (artist == null)
                {
                    throw new Exception("Artist is not found");
                }    
                else
                {
                    artistName += artist.VietnameseName + splitCharacter;
                }   
            }
            return artistName.Remove(artistName.LastIndexOf(splitCharacter)).TrimEnd();   
        }
    }
}
