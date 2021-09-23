using System.Collections.Generic;

namespace Website.Models
{
    public class ModalViewModel
    {
        public class Song
        {
            public Song(string id, IEnumerable<Music.Models.Song> items)
            {
                Id = id;
                Items = items;
            }

            public string Id { get; }

            public IEnumerable<Music.Models.Song> Items { get; }
        }
    }
}
