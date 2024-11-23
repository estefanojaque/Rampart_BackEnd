using Rampart_BackEnd.Dishes.Domain.Model.Aggregates;
using Rampart_BackEnd.Shared.Domain.Repositories;

namespace Rampart_BackEnd.Dishes.Domain.Repositories;

public interface IDishRepository : IBaseRepository<Dish>
{
    Task<IEnumerable<Dish>> FindByChefIdAsync(int chefId);

    Task<bool> ExistsByNameOfDishAndChefIdAsync(string nameOfDish, int chefId);
}