using System;

namespace Music.Enumerables
{
    public enum Category
    {
        Unknown = 252,

        #region Gender
        Default = 0,
        Male = 1,
        Female = 2,
        Band = 3,
        #endregion

        #region Genre
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
        Traditional,
        #endregion

        #region Type
        Song = 60,
        Artist,
        Album,
        Video,
        #endregion

        #region Alphabet
        Alphabet = 64,
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
        #endregion
    }
}
