using System.Collections;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Peanuts.Woodstock.Infrastructure.Data.Contexts;

namespace Peanuts.Woodstock.Infrastructure.Data;

public interface IDbCollection<TEntity> : IEnumerable<TEntity> {
    ValueTask<TEntity?> FindAsync(Guid publicId);
    IDbCollection<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    IDbCollection<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPath);
}

internal class DbCollection<TEntity>(IDbContextFactory<WoodstockContext> factory) : IDbCollection<TEntity> where TEntity : class
{
    private IQueryable<TEntity> _query = factory.CreateDbContext().Set<TEntity>();
    private readonly DbSet<TEntity> _entities = factory.CreateDbContext().Set<TEntity>();

    public ValueTask<TEntity?> FindAsync(Guid publicId) => _entities.FindAsync(publicId);

    public IDbCollection<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        _query = _query.Where(predicate);
        return this;
    }

    public IDbCollection<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPath) {
        _query = _query.Include(navigationPath);
        return this;
    }

    public IEnumerator<TEntity> GetEnumerator() => _query.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
