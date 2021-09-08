using Music.Resources.Transtation;
using System;

namespace Music.Enumerables
{
    public static class Category
    {
        public enum Gender
        {
            Default = 0,
            Male = 1,
            Female = 2,
            Band = 3,
            Other = 4
        }

        public enum Genre
        {
            Blues = 10,
            Cover,
            Electronic,
            Folk,
            Hot,
            New,
            Original,
            Pop,
            Popular,
            Rap,
            Recommend,
            Rock,
            RnB,
            Single,
            Traditional
        }

        public enum Alphabet
        {
            Number = 64,
            A = ConsoleKey.A,
            B = ConsoleKey.B,
            C = ConsoleKey.C,
            D = ConsoleKey.D,
            E = ConsoleKey.E,
            F = ConsoleKey.F,
            G = ConsoleKey.G,
            H = ConsoleKey.H,
            I = ConsoleKey.I,
            J = ConsoleKey.J,
            K = ConsoleKey.K,
            L = ConsoleKey.L,
            M = ConsoleKey.M,
            N = ConsoleKey.N,
            O = ConsoleKey.O,
            P = ConsoleKey.P,
            Q = ConsoleKey.Q,
            R = ConsoleKey.R,
            S = ConsoleKey.S,
            T = ConsoleKey.T,
            U = ConsoleKey.U,
            V = ConsoleKey.V,
            W = ConsoleKey.W,
            X = ConsoleKey.X,
            Y = ConsoleKey.Y,
            Z = ConsoleKey.Z,
            Other = 91
        }

        public enum SongGenre
        {
            Orginal = 100,
            Cover
        }

        public enum AlbumGenre
        {
            Single = 200
        }

        public enum ArtistGenre
        {
            Njt = 300
        }

        public static string ToString(this string text, Language language = default)
        {
            return language switch
            {
                Language.Vietnamese => VietnameseString.ResourceManager.GetString(text) ?? text,
                _ => text,
            };
        }
    }
}
