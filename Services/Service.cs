using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Services
{
    public class Service : IService
    {

        private readonly RepoDbContext _repository;

        public Service(RepoDbContext repository) {
            _repository = repository;
        }

        public async Task DeleteMusician(int id)
        {
            var musician = new Musician {
                IdMusician = id
            };

            _repository.Musicians.Remove(musician);
            await this.SaveChangesAsync();
        }

        public IQueryable<Musician> GetMusicianById(int id)
        {
            return _repository.Musicians.Where(e => e.IdMusician == id);
        }

        public IQueryable<MusicianTrack> GetMusicianTracksById(int id)
        {
            return _repository.MusicianTracks
                .Where(e => e.IdMusician == id)
                .Include(e => e.Track);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
    }
}