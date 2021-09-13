using Music.Enumerables;

namespace Music.Interfaces
{
    interface IProfile : IFullName, IDescription
    {
        string Id { get; set; }

        string Birthday { get; set; }

        string Address { get; set; }
    }
}
