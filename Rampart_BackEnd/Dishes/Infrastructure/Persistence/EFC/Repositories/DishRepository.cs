using Microsoft.EntityFrameworkCore;
using Rampart_BackEnd.Dishes.Domain.Model.Aggregates;
using Rampart_BackEnd.Dishes.Domain.Repositories;
using Rampart_BackEnd.Shared.Infrastructure.Persistence.EFC.Configuration;
using Rampart_BackEnd.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Rampart_BackEnd.Dishes.Infrastructure.Persistence.EFC.Repositories;

public class DishRepository(AppDbContext context): BaseRepository<Dish>(context), IDishRepository
{
    public async Task<IEnumerable<Dish>> FindByChefIdAsync(int chefId)
    {
        return await Context.Set<Dish>().Where(d => d.ChefId == chefId).ToListAsync();
    }

    public async Task<bool> ExistsByNameOfDishAndChefIdAsync(string nameOfDish, int chefId)
    {
        return await Context.Set<Dish>()
            .AnyAsync(d => d.NameOfDish == nameOfDish && d.ChefId == chefId);
    }

}