using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Models;

namespace kol2.Services
{
    public interface IService
    {
        Task SaveChangesAsync();
        IQueryable<Musician> GetMusicianById(int id);
        IQueryable<MusicianTrack> GetMusicianTracksById(int id);

        Task DeleteMusician(int id);
    }
}