using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models.DTO
{
    public class MusicianInfo
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Nickname {get; set;}

        public ICollection<TrackDTO> Tracks {get; set;} = null!;
    }

    public class TrackDTO {
        public float Duration {get; set;}
        public string TrackName { get; set; } = null!;
        public int? IdMusicAlbum {get; set;}
    }
}