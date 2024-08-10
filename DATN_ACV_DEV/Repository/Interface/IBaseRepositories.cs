using System.Linq.Expressions;

namespace DATN_ACV_DEV.Repository.Interface
{
    public interface IBaseRepositories<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> FindAsync(params Object[] keyValues);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByGuidIdAsync(Guid id);

        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteObjAsync(TEntity entity);

        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAllByID(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> WhereIQueryable(Expression<Func<TEntity, bool>> predicate);

    }
}
