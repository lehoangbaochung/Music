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
        private static string GetButtonName(this ConsoleColor color)
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

        public static string GetViewName(this Artist artist, string category)
        {
            return category == null ? $"{ nameof(Artist) }/Detail" : $"{ nameof(Artist) }/{ category }";
        }

        private static string GetViewName(Category category)
        {
            return $"~/Views/Shared/Partial/{ category }.cshtml";
        }

        public static ProfileViewModel GetProfile(this Artist artist, string category)
        {
            var relatedArtist = DataProvider.Artists[
                new Random().Next(0, DataProvider.Artists.Count)];

            ProfileViewModel viewModel = new();           
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
            viewModel.Items.AddRange(artist.GetModels(category));
            return viewModel;
        }

        private static ItemViewModel[] GetModels(this Artist artist, string category)
        {
            var models = new ItemViewModel[]
            {
                new()
                {
                    ViewName = GetViewName(Category.List),
                    Header = nameof(Song).ToString(Language.Vietnamese),
                    Items = artist.GetRecentSongs(10),
                    Hyperlink = new("Home", nameof(Artist), null, nameof(Song))
                },
                new()
                {
                    ViewName = GetViewName(Category.Grid),
                    Header = nameof(Album).ToString(Language.Vietnamese),
                    Items = artist.GetRecentAlbums(6),
                    Hyperlink = new("Home", nameof(Artist), null, nameof(Album))
                },
                new()
                {
                    Items = artist.GetRecentVideos(6),
                    ViewName = GetViewName(Category.Grid),
                    Header = nameof(Video).ToString(Language.Vietnamese),
                    Hyperlink = new("Home", nameof(Artist), null, nameof(Video))
                }
            };

            if (category != null)
            {
                models[0].Hyperlink = null;
                models[1].Hyperlink = null;
                models[2].Hyperlink = null;

                models[0].Items = artist.GetSongs();
                models[1].Items = artist.GetAlbums();
                models[2].Items = artist.GetVideos();
            }    
            
            return models;
        }

        public static ProfileViewModel GetProfile(this Album album)
        {
            ProfileViewModel viewModel = new();
            viewModel.Profile = new()
            {
                Title = album.VietnameseName,
                Subtitle = album.SimplifiedChineseName,
                ImageUrl = album.ImageUrl,
                Color = ConsoleColor.Magenta.ToString().ToLower()
            };
            viewModel.Summaries.AddRange(new Profile[]
            {
                // Song
                new()
                {
                    Title = nameof(Song).ToString(Language.Vietnamese),
                    Subtitle = album.GetSongs().Count.ToString(),
                    Color = ConsoleColor.Green.GetButtonName(),
                    Hyperlink = new("Home", nameof(Album), null, nameof(Song))
                },
                // Album
                new()
                {
                    Title = nameof(Artist).ToString(Language.Vietnamese),
                    Subtitle = album.GetArtists().Count.ToString(),
                    Color = ConsoleColor.Yellow.GetButtonName(),
                    Hyperlink = new("Home", nameof(Album), null, nameof(Artist))
                },
                // Video
                new()
                {
                    Title = nameof(Video).ToString(Language.Vietnamese),
                    Subtitle = album.GetVideos().Count.ToString(),
                    Color = ConsoleColor.Red.GetButtonName(),
                    Hyperlink = new("Home", nameof(Album), null, nameof(Video))
                }
            });
            viewModel.Informations.AddRange(new Profile[]
            {
                new()
                {
                    Title = "Ca sĩ",
                    Subtitle = "Đang cập nhật"
                },
                new()
                {
                    Title = "Ngày phát hành",
                    Subtitle = "Đang cập nhật"
                },
                new()
                {
                    Title = "Thể loại",
                    Subtitle = "Single"
                },
                new()
                {
                    Title = "Hãng đĩa",
                    Subtitle = "Đang cập nhật"
                }
            });
            var otherAlbum = DataProvider.Albums.GetRandomItem();
            viewModel.RelatedProfiles.AddRange(new Profile[]
            {
                new()
                {
                    Hyperlink = new("Home", nameof(Album), otherAlbum.Id, null),
                    Title = otherAlbum.VietnameseName,
                    Subtitle = otherAlbum.SimplifiedChineseName,
                    ImageUrl = otherAlbum.ImageUrl,
                    Color = otherAlbum.Category.Equals(Category.Male) ?
                        ConsoleColor.Blue.ToString().ToLower() :
                        ConsoleColor.Red.ToString().ToLower()
                }
            });
            return viewModel;
        }
    }
}
