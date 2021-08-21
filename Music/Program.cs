using System;

namespace Music
{
    class Program
    {
        static void Main()
        {
            foreach (var item in Utilies.DataProvider.Albums)
            {
                foreach (var song in item.Songs)
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.WriteLine($"{ song.Id }: { song.VietnameseName }");
                }    
                
            }
            Console.ReadKey();
        }
    }
}
