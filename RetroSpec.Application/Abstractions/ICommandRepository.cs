using RetroSpec.Core.Abstractions;

namespace RetroSpec.Application.Abstractions;

public interface ICommandRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
    Task AddAsync(TAggregateRoot aggregateRoot);
    void Delete(TAggregateRoot aggregateRoot);
    Task<TAggregateRoot> FirstAsync(System.Linq.Expressions.Expression<Func<TAggregateRoot, bool>>? predicate = null, Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null, string includedProperties = "");
    Task<TAggregateRoot?> FirstOrDefaultAsync(System.Linq.Expressions.Expression<Func<TAggregateRoot, bool>>? predicate = null, Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null, string includedProperties = "");
    Task<IReadOnlyCollection<TAggregateRoot>> GetAllAsync(System.Linq.Expressions.Expression<Func<TAggregateRoot, bool>>? predicate = null, Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null, string includedProperties = "");
    void Update(TAggregateRoot aggregateRoot);
}
