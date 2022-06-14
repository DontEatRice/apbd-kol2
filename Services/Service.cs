using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Models;

namespace kol2.Services
{
    public class Service : IService
    {

        private readonly RepoDbContext _repository;

        public Service(RepoDbContext repository) {
            _repository = repository;
        }
        public async Task CreateAsync<T>(T entity) where T : class
        {
            await _repository.Set<T>().AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
    }
}