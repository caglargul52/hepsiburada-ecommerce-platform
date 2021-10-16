using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Domain.Common;
using ECommercePlatform.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlatform.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        public ApplicationContext Context { get; }

        public Repository(ApplicationContext context)
        {
            Context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Context.Set<T>().Update(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }
    }
}

