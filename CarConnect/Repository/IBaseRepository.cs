using CarConnect.Entities.Base;
using System.Linq.Expressions;

namespace CarConnect.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(Guid id);
    }
}
