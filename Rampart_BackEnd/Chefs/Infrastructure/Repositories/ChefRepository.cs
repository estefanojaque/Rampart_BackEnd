using Microsoft.EntityFrameworkCore;
using Rampart_BackEnd.Chefs.Domain.Model.Aggregates;
using Rampart_BackEnd.Chefs.Domain.Repositories;
using Rampart_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;
using Rampart_BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Rampart_BackEnd.Chefs.Infrastructure.Repositories;

public class ChefRepository(AppDbContext context) : BaseRepository<Chef>(context), IChefRepository
{
    public async Task<IEnumerable<Chef>> FindByIdAsync(int id)
    {
        return await Context.Set<Chef>().Where(d => d.Id == id).ToListAsync();
    }
    
    public async Task<IEnumerable<Chef>> FindByNameAsync(string name)
    {
        return await Context.Set<Chef>()
            .Where(c => c.Name.Contains(name))  // Ejemplo de búsqueda por nombre
            .ToListAsync();
    }

    public async Task<IEnumerable<Chef>> FindByRatingAsync(double rating)
    {
        return await Context.Set<Chef>()
            .Where(c => c.Rating >= rating)  // Ejemplo de búsqueda por rating
            .ToListAsync();
    }
    
    public async Task<bool> ExistsByTitleAsync(string name)
    {
        return await Context.Set<Chef>()
            .AnyAsync(c => c.Name == name);
    }
}
