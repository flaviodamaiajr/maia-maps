using Maia.Maps.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Maia.Maps.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }
    }
}
