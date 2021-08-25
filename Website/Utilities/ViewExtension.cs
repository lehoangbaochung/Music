using Music.Enumerables;
using Music.Extensions;
using Music.Models;
using Music.Utilities;
using System;
using Website.Models;
using Website.ViewModels;

namespace Website.Utilities
{
    /// <summary>
    /// ngrok http https://localhost:44397 -host-header="localhost:44397"
    /// </summary>
    public static class ViewExtension
    {
        static ProfileViewModel viewModel;

        static string GetButtonName(this ConsoleColor color)
        {
            return color switch
            {
                ConsoleColor.Black => "dark",
                ConsoleColor.Blue => "primary",
                ConsoleColor.DarkBlue => "info",
                ConsoleColor.Gray => "secondary",
                ConsoleColor.Green => "success",
                ConsoleColor.Red => "danger",
                ConsoleColor.White => "light",
                ConsoleColor.Yellow => "warning",
                _ => color.ToString().ToLower(),
            };
        }

        public static ProfileViewModel GetProfile(this Artist artist)
        {
            var relatedArtist = DataProvider.Artists[
                new Random().Next(0, DataProvider.Artists.Count)];

            viewModel = new();
            viewModel.Profile = new()
            {
                Title = artist.VietnameseName,
                Subtitle = artist.SimplifiedChineseName,
                ImageUrl = artist.ImageUrl,
                Color = artist.Category.Equals(Category.Male) ?
                    ConsoleColor.Blue.ToString().ToLower() :
                    ConsoleColor.Red.ToString().ToLower()
            };
            viewModel.Summaries.AddRange(new Profile[]
            {
                // Song
                new()
                {
                    Title = nameof(Song).ToString(Language.Vietnamese),
                    Subtitle = artist.GetSongs().Count.ToString(),
                    Color = ConsoleColor.Green.GetButtonName(),
                    Hyperlink = new("Home", nameof(Artist), null, nameof(Song))
                },
                // Album
                new()
                {
                    Title = nameof(Album).ToString(Language.Vietnamese),
                    Subtitle = artist.GetAlbums().Count.ToString(),
                    Color = ConsoleColor.Yellow.GetButtonName(),
                    Hyperlink = new("Home", nameof(Artist), null, nameof(Album))
                },
                // Video
                new()
                {
                    Title = nameof(Video).ToString(Language.Vietnamese),
                    Subtitle = artist.GetVideos().Count.ToString(),
                    Color = ConsoleColor.Red.GetButtonName(),
                    Hyperlink = new("Home", nameof(Artist), null, nameof(Video))
                }
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
                    Hyperlink = new("Home", nameof(Artist), relatedArtist.Id, null),
                    Title = relatedArtist.VietnameseName,
                    Subtitle = relatedArtist.SimplifiedChineseName,
                    ImageUrl = relatedArtist.ImageUrl,
                    Color = relatedArtist.Category.Equals(Category.Male) ? 
                        ConsoleColor.Blue.ToString().ToLower() : 
                        ConsoleColor.Red.ToString().ToLower()
                }
            });

            return viewModel;
        }
    }
}
