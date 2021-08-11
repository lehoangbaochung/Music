using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class AlbumArtist
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string AlbumId { get; set; }

        [Required]
        public string ArtistId { get; set; }
    }
}
