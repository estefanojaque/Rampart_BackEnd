using Rampart_BackEnd.Chefs.Domain.Model.Aggregates;
using Rampart_BackEnd.Shared.Domain.Repositories;

namespace Rampart_BackEnd.Chefs.Domain.Repositories;

public interface IChefRepository : IBaseRepository<Chef>
{
    Task<bool> ExistsByTitleAsync(string Name);
}