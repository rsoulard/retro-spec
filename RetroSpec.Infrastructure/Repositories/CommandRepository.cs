using Microsoft.EntityFrameworkCore;
using RetroSpec.Application.Abstractions;
using RetroSpec.Core.Abstractions;
using RetroSpec.Infrastructure.DataAccess;
using System.Linq.Expressions;

namespace RetroSpec.Infrastructure.Repositories;

internal class CommandRepository<TAggregateRoot>(RetroDbContext dbContext) : ICommandRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
    private readonly RetroDbContext dbContext = dbContext;
    private readonly DbSet<TAggregateRoot> dbSet = dbContext.Set<TAggregateRoot>();

    public async Task<IReadOnlyCollection<TAggregateRoot>> GetAllAsync(
    Expression<Func<TAggregateRoot, bool>>? predicate = null,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null,
        string includedProperties = "")
    {
        return await PrepareQuery(predicate, orderBy, includedProperties).ToListAsync();
    }

    public async Task<TAggregateRoot?> FirstOrDefaultAsync(
    Expression<Func<TAggregateRoot, bool>>? predicate = null,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null,
        string includedProperties = "")
    {
        return await PrepareQuery(predicate, orderBy, includedProperties).FirstOrDefaultAsync();
    }

    public async Task<TAggregateRoot> FirstAsync(
    Expression<Func<TAggregateRoot, bool>>? predicate = null,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null,
        string includedProperties = "")
    {
        return await PrepareQuery(predicate, orderBy, includedProperties).FirstAsync();
    }

    private IQueryable<TAggregateRoot> PrepareQuery(
    Expression<Func<TAggregateRoot, bool>>? predicate = null,
    Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null,
        string includedProperties = "")
    {
        var query = dbSet.AsQueryable();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        query = includedProperties
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty.Trim()));

        return orderBy is not null ? orderBy(query) : query;
    }

    public async Task AddAsync(TAggregateRoot aggregateRoot)
    {
        await dbSet.AddAsync(aggregateRoot);
    }

    public void Update(TAggregateRoot aggregateRoot)
    {
        dbSet.Attach(aggregateRoot);
        dbContext.Entry(aggregateRoot).State = EntityState.Modified;
    }

    public void Delete(TAggregateRoot aggregateRoot)
    {
        if (dbContext.Entry(aggregateRoot).State == EntityState.Deleted)
        {
            dbSet.Attach(aggregateRoot);
        }

        dbSet.Remove(aggregateRoot);
    }
}
