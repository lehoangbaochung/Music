using System;

namespace Music
{
    class Program
    {
        static void Main()
        { 
            foreach (var song in Utilies.DataProvider.Songs)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine($"{ song.Id }: { song.VietnameseName } - { song.GetArtistName() }");
            }
            Console.ReadKey();
        }
    }
}
