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
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> Where(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }
    }
}

