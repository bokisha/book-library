using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookLibrary.Core.Entities;
using BookLibrary.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.DAL.InMemory.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbSet<T> DbSet;

        public GenericRepository(BookLibraryDbContext dataContext)
        {
            DbSet = dataContext.Set<T>();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await DbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            var exist = await DbSet.Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }

            DbSet.Remove(exist);

            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<bool> Update(T entity)
        {
            var existingEntity = await DbSet.Where(x => x.Id == entity.Id)
                .FirstOrDefaultAsync();

            if (existingEntity == null)
            {
                return false;
            }

            DbSet.Update(entity);

            return true;
        }
    }
}
