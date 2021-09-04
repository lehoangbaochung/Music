using Music.Enumerables;
using Music.Extensions;
using Music.Models;
using Music.Utilities;
using System;
using System.Collections.Generic;
using Website.Models;
using Website.ViewModels;

namespace Website.Utilities
{
    /// <summary>
    /// ngrok http https://localhost:44397 -host-header="localhost:44397"
    /// </summary>
    public static class ViewExtension
    {
        public const string PROFILE_VIEW_PATH = "~/Views/Shared/Profile.cshtml";
        private const string LIST_VIEW_PATH = "~/Views/Shared/Song.cshtml";
        private const string GRID_VIEW_PATH = "~/Views/Shared/Album.cshtml";
        private const string VIDEO_VIEW_PATH = "~/Views/Shared/Video.cshtml";
        //private const string NAVIGATION_VIEW_PATH = "~/Views/Shared/Partial/Navigation.cshtml";

        private static string GetButtonColorName(ConsoleColor color)
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

        public static Hyperlink GetHyperlink(Base @base)
        {
            return new Hyperlink("Home", @base.GetType().Name, @base.Id);
        }

        public static ProfileViewModel GetProfile(this Artist artist)
        {
            var relatedArtist = DataProvider.Artists.GetRandomItem();

            ProfileViewModel model = new()
            {
                PrimaryItem = new()
                {
                    ImageUrl = artist.ImageUrl,
                    Title = artist.VietnameseName,
                    Subtitle = artist.SimplifiedChineseName,
                    ColorName = artist.Category.Equals(Category.Male) ?
                        ConsoleColor.Blue.ToString().ToLower() :
                        ConsoleColor.Red.ToString().ToLower()
                },
                SecondaryItem = new()
                {
                    ImageUrl = relatedArtist.ImageUrl,
                    Title = relatedArtist.VietnameseName,
                    Subtitle = relatedArtist.SimplifiedChineseName,
                    Hyperlink = new("Home", nameof(Artist), relatedArtist.Id),
                    ColorName = relatedArtist.Category.Equals(Category.Male) ?
                        ConsoleColor.Blue.ToString().ToLower() :
                        ConsoleColor.Red.ToString().ToLower()
                }
            };
            model.Parameters.AddRange(new Item[]
            {
                // Song
                new()
                {
                    Title = nameof(Song).ToString(Language.Vietnamese),
                    Subtitle = artist.GetSongs().Count.ToString(),
                    ColorName = GetButtonColorName(ConsoleColor.Green)
                },
                // Album
                new()
                {
                    Title = nameof(Album).ToString(Language.Vietnamese),
                    Subtitle = artist.GetAlbums().Count.ToString(),
                    ColorName = GetButtonColorName(ConsoleColor.Yellow)
                },
                // Video
                new()
                {
                    Title = nameof(Video).ToString(Language.Vietnamese),
                    Subtitle = artist.GetVideos().Count.ToString(),
                    ColorName = GetButtonColorName(ConsoleColor.Red)
                }
            });
            model.Informations.AddRange(new Item[]
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
            model.Navigations.AddRange(new NavigationViewModel[]
            {
                new()
                {
                    Items = artist.GetRecentSongs(15),
                    ViewName = LIST_VIEW_PATH,
                    Header = nameof(Song)
                },
                new()
                {
                    Items = artist.GetRecentAlbums(12),
                    ViewName = GRID_VIEW_PATH,
                    Header = nameof(Album)
                },
                new()
                {
                    Items = artist.GetRecentVideos(12),
                    ViewName = VIDEO_VIEW_PATH,
                    Header = nameof(Video)
                }
            });
            return model;
        }

        public static ProfileViewModel GetProfile(this Album album)
        {
            var relatedAlbum = album.GetRelatedAlbum();

            ProfileViewModel model = new()
            {
                PrimaryItem = new()
                {
                    ImageUrl = album.ImageUrl,
                    Title = album.VietnameseName,
                    Subtitle = album.SimplifiedChineseName,
                    ColorName = album.Category.Equals(Category.Male) ?
                        ConsoleColor.Blue.ToString().ToLower() :
                        ConsoleColor.Red.ToString().ToLower()
                },
                SecondaryItem = new()
                {
                    ImageUrl = relatedAlbum.ImageUrl,
                    Title = relatedAlbum.VietnameseName,
                    Subtitle = relatedAlbum.SimplifiedChineseName,
                    Hyperlink = new("Home", nameof(Album), relatedAlbum.Id),
                    ColorName = relatedAlbum.Category.Equals(Category.Male) ?
                        ConsoleColor.Blue.ToString().ToLower() :
                        ConsoleColor.Red.ToString().ToLower()
                }
            };
            model.Parameters.AddRange(new Item[]
            {
                // Song
                new()
                {
                    Title = nameof(Song).ToString(Language.Vietnamese),
                    Subtitle = album.GetSongs().Count.ToString(),
                    ColorName = GetButtonColorName(ConsoleColor.Green)
                },
                // Album
                new()
                {
                    Title = nameof(Artist).ToString(Language.Vietnamese),
                    Subtitle = album.GetArtists().Count.ToString(),
                    ColorName = GetButtonColorName(ConsoleColor.Yellow)
                },
                // Video
                new()
                {
                    Title = nameof(Video).ToString(Language.Vietnamese),
                    Subtitle = album.GetVideos().Count.ToString(),
                    ColorName = GetButtonColorName(ConsoleColor.Red)
                }
            });
            model.Informations.AddRange(new Item[]
            {
                new()
                {
                    Title = "Thể loại",
                    Subtitle = "Đang cập nhật"
                },
                new()
                {
                    Title = "Phát hành",
                    Subtitle = "Đang cập nhật"
                },
                new()
                {
                    Title = "Hãng đĩa",
                    Subtitle = "Đang cập nhật"
                },
                new()
                {
                    Title = "Đĩa đơn",
                    Subtitle = "Đang cập nhật"
                }
            });
            model.Navigations.AddRange(new NavigationViewModel[]
            {
                new()
                {
                    Items = album.GetSongs(),
                    ViewName = LIST_VIEW_PATH,
                    Header = nameof(Song)
                },
                new()
                {
                    Items = album.GetArtists(),
                    ViewName = GRID_VIEW_PATH,
                    Header = nameof(Artist)
                },
                new()
                {
                    Items = album.GetVideos(),
                    ViewName = VIDEO_VIEW_PATH,
                    Header = nameof(Video)
                }
            });
            return model;
        }

        public static string GetImageBorderColorName(this Artist artist)
        {
            return artist.Category.Equals(Category.Male) ? "blue" : "pink";
        }
    }
}
