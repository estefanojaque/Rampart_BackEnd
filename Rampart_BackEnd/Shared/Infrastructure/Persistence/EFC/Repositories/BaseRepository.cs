using Microsoft.EntityFrameworkCore;
using Rampart_BackEnd.Shared.Domain.Repositories;
using Rampart_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Rampart_BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context;
    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }
    public async Task AddSync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity); 
    }

    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}