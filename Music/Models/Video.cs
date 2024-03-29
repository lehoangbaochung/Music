﻿using Music.Enumerables;
using Music.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Video : Base
    {
        [Required]
        public string SongId { get; set; }

        [Required]
        [Display(Name = "Thời lượng")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Ngày đăng")]
        public string ReleaseDate { get; set; }

        public string ImageUrl
            => GetImageUrl(ImageResolution.MQDefault);

        public Video() { }
    }
}
