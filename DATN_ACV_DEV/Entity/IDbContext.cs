using Microsoft.EntityFrameworkCore;

namespace DATN_ACV_DEV.Entity
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> SetEntity<TEntity>() where TEntity : class;
        Task<int> CommitChangesAsync();
    }
}
