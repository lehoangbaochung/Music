using Music.Enumerables;
using Music.Models;
using System;
using Website.Models;

namespace Website.Helpers
{
    public static class ProfileHelper
    {
        static ProfileViewModel viewModel;

        public static ProfileViewModel GetProfile(Artist artist)
        {
            if (artist == null)
            {
                throw new NullReferenceException("Artist is null");
            }

            viewModel = new();
            viewModel.Profile = new()
            {
                Title = artist.VietnameseName,
                Subtitle = artist.SimplifiedChineseName,
                ImageUrl = artist.ImageUrl,
                Color = artist.Gender.Equals(Gender.Male) ? "blue" : "red"
            };
            viewModel.Summaries.AddRange(new Profile[]
            {
                // Song
                new()
                {
                    Id = nameof(Song),
                    Title = "Bài hát",
                    Subtitle = artist.Songs.Count.ToString(),
                    Color = "success"
                },
                // Album
                new()
                {
                    Id = nameof(Album),
                    Title = "Album",
                    Subtitle = artist.Albums.Count.ToString(),
                    Color = "warning"
                },
                // Artist
                new()
                {
                    Id = nameof(Video),
                    Title = "Video",
                    Subtitle = artist.Videos.Count.ToString(),
                    Color = ConsoleColor.Red.GetName()
                },
            });
            viewModel.Informations.AddRange(new Profile[]
            {
                new()
                {
                    Title = "Tên thật",
                    Subtitle = "Đang cập nhật"
                },
                new()
                {
                    Title = "Giới tính",
                    Subtitle = "Đang cập nhật"
                },
                new()
                {
                    Title = "Ngày sinh",
                    Subtitle = "Đang cập nhật"
                },
                new()
                {
                    Title = "Quê quán",
                    Subtitle = "Đang cập nhật"
                }
            });
            viewModel.RelatedProfiles.AddRange(new Profile[]
            {
                new()
                {
                    Id = "002vALgR3hRRlv",
                    Title = artist.VietnameseName,
                    Subtitle = artist.SimplifiedChineseName,
                    ImageUrl = artist.ImageUrl,
                    Color = artist.Gender.Equals(Gender.Male) ? "blue" : "red"
                }
            });

            return viewModel;
        }

        static string GetName(this ConsoleColor color)
        {
            return color switch
            {
                ConsoleColor.Black => "dark",
                ConsoleColor.Blue => "info",
                ConsoleColor.DarkBlue => "primary",
                ConsoleColor.Gray => "secondary",
                ConsoleColor.Green => "screen",
                ConsoleColor.Red => "danger",
                ConsoleColor.White => "light",
                ConsoleColor.Yellow => "warning",
                _ => color.ToString(),
            };
        }
    }
}
