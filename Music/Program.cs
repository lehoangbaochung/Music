using Music.Extensions;
using System;

namespace Music
{
    class Program
    {
        static void Main()
        {
            foreach (var album in DataProvider.Albums)
            {
                Console.WriteLine($"{album.VietnameseName}: {album.GetArtists()[0].VietnameseName}");
            }    
            Console.ReadKey();
        }
    }
}
