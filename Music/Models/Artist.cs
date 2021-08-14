﻿namespace Music.Models
{
    public class Artist : User
    {
        public string PlaylistId { get; set; }

        public new string ImageUrl
            => Resource.ImageServerUrl + Resource.ArtistImageId
             + Resource.ImageCode + Id + Resource.ImageExtension;
    }
}