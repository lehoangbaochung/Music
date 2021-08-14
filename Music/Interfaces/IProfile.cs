namespace Music.Interfaces
{
    interface IProfile : IFullName, IDescription
    {
        string Id { get; set; }

        int? Gender { get; set; }

        string Birthday { get; set; }

        string Address { get; set; }

        string ImageUrl { get; }
    }
}
