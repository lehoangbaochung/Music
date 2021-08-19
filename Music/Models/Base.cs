using Music.Enumerables;
using Music.Interfaces;
using Music.Utilies;
using System;

namespace Music.Models
{
    public class Base : IName, IDescription
    {
        private const char JOIN_CHARACTER = '-';
        private const string SPLIT_CHARACTER = "/";

        public string Id { get; set; }
        public string ArtistId { get; set; }
        public string VietnameseName { get; set; }
        public string PinyinName { get; set; }
        public string SimplifiedChineseName { get; set; }
        public string TraditionalChineseName { get; set; }
        public string VietnameseDescription { get; set; }
        public string SimplifiedChineseDescription { get; set; }
        public string TraditionalChineseDescription { get; set; }

        protected static string GetImageUrl(string id, ImageSize imageSize = ImageSize.Medium)
        {
            return Resource.ImageServerUrl + Resource.AlbumImageId +
                imageSize.GetImageCode() + id + Resource.ImageExtension;
        }

        public string GetArtistName(string splitCharacter = SPLIT_CHARACTER, Language language = default)
        {
            var artistName = string.Empty;
            foreach (var artistId in ArtistId.Split(JOIN_CHARACTER))
            {
                var artist = DataProvider.Artists.Find(a => a.Id.Equals(artistId));
                if (artist == null)
                {
                    throw new NullReferenceException("Artist is not found");
                }
                else
                {
                    artistName += language switch
                    {
                        Language.English => artist.PinyinName + splitCharacter,
                        Language.SimplifiedChinese => artist.SimplifiedChineseName + splitCharacter,
                        Language.TraditionalChinese => artist.TraditionalChineseName + splitCharacter,
                        _ => artist.VietnameseName + splitCharacter,
                    };
                }
            }
            return artistName.Remove(artistName.LastIndexOf(splitCharacter)).TrimEnd();
        }
    }
}
