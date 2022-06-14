using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }

        public virtual MusicLabel Label {get; set;} = null!;
        public virtual ICollection<Track> Tracks {get; set;} = null!;
    }
}