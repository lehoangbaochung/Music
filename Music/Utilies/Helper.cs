using Music.Enumerables;

namespace Music.Utilies
{
    static class Helper
    {
        public static string GetImageCode(this ImageSize imageSize)
        {
            return $"R{ (int)imageSize }x{ (int)imageSize }M000";   
        }
    }
}
