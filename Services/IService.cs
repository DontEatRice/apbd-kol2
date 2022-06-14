using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Services
{
    public interface IService
    {
        Task SaveChangesAsync();
        Task CreateAsync<T>(T entity) where T : class;
    }
}