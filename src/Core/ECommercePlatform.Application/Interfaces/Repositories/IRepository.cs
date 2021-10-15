using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<bool> AddAsync(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> expression);
    }
}
