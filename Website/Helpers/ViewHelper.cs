using Music.Enumerables;
using Music.Models;
using Music.Utilities;
using System;
using Website.Models;

namespace Website.Helpers
{
    /// <summary>
    /// ngrok http https://localhost:44397 -host-header="localhost:44397"
    /// </summary>
    public static class ViewHelper
    {
        static ProfileViewModel viewModel;

        public static ProfileViewModel GetProfile(Artist artist)
        {
            if (artist == null)
            {
                throw new NullReferenceException("Artist is null");
            }

            var relatedArtist = DataProvider.Artists[new Random().Next(0, DataProvider.Artists.Count)];

            viewModel = new();
            viewModel.Profile = new()
            {
                Title = artist.VietnameseName,
                Subtitle = artist.SimplifiedChineseName,
                ImageUrl = artist.ImageUrl,
                Color = artist.Gender.Equals(Gender.Male) ?
                    ConsoleColor.Blue.GetLowerName() :
                    ConsoleColor.Red.GetLowerName()
            };
            viewModel.Summaries.AddRange(new Profile[]
            {
                // Song
                new()
                {
                    Id = nameof(Song),
                    Title = "Bài hát",
                    Subtitle = artist.Songs.Count.ToString(),
                    Color = ConsoleColor.Green.GetButtonName()
                },
                // Album
                new()
                {
                    Id = nameof(Album),
                    Title = "Album",
                    Subtitle = artist.Albums.Count.ToString(),
                    Color = ConsoleColor.Yellow.GetButtonName()
                },
                // Artist
                new()
                {
                    Id = nameof(Video),
                    Title = "Video",
                    Subtitle = artist.Videos.Count.ToString(),
                    Color = ConsoleColor.Red.GetButtonName()
                },
            }); ;
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
                    Id = relatedArtist.Id,
                    Title = relatedArtist.VietnameseName,
                    Subtitle = relatedArtist.SimplifiedChineseName,
                    ImageUrl = relatedArtist.ImageUrl,
                    Color = relatedArtist.Gender.Equals(Gender.Male) ? 
                        ConsoleColor.Blue.GetLowerName() : 
                        ConsoleColor.Red.GetLowerName()
                }
            });

            return viewModel;
        }

        static string GetButtonName(this ConsoleColor color)
        {
            return color switch
            {
                ConsoleColor.Black => "dark",
                ConsoleColor.Blue => "info",
                ConsoleColor.DarkBlue => "primary",
                ConsoleColor.Gray => "secondary",
                ConsoleColor.Green => "success",
                ConsoleColor.Red => "danger",
                ConsoleColor.White => "light",
                ConsoleColor.Yellow => "warning",
                _ => color.ToString(),
            };
        }

        static string GetLowerName(this ConsoleColor color)
        {
            return color.ToString().ToLower();
        }
    }
}
