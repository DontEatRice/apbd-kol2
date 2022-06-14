namespace kol2.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Nickname {get; set;}
        public virtual ICollection<MusicianTrack> MusicianTracks {get; set;} = null!;
    }
}