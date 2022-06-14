using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public float Duration {get; set;}
        public string TrackName { get; set; } = null!;
        public int? IdMusicAlbum {get; set;}

        public virtual Album? Album {get; set;}
        public virtual ICollection<MusicianTrack> MusicianTracks {get; set;} = null!;
    }
}