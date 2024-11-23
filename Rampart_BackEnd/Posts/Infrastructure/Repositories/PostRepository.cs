using Microsoft.EntityFrameworkCore;
using Rampart_BackEnd.Posts.Domain.Model.Aggregates;
using Rampart_BackEnd.Posts.Domain.Repositories;
using Rampart_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;
using Rampart_BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Rampart_BackEnd.Posts.Infrastructure.Repositories;

public class PostRepository(AppDbContext context) : BaseRepository<Post>(context), IPostRepository
{
    public async Task<IEnumerable<Post>> FindAllAsync()
    {
        return await Context.Set<Post>().ToListAsync();
    }

    public async Task<IEnumerable<Post>> FindByDishIdAsync(int dishId)
    {
        return await Context.Set<Post>()
            .Where(post => post.dishId == dishId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Post post)
    {
        Context.Set<Post>().Update(post);
        await Context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Post post)
    {
        Context.Set<Post>().Remove(post);
        await Context.SaveChangesAsync();
    }
}