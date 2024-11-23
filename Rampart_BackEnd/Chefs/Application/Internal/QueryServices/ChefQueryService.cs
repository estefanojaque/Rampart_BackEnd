using Rampart_BackEnd.Chefs.Domain.Model.Aggregates;
using Rampart_BackEnd.Chefs.Domain.Model.Queries;
using Rampart_BackEnd.Chefs.Domain.Repositories;
using Rampart_BackEnd.Chefs.Domain.Services;

namespace Rampart_BackEnd.Chefs.Application.Internal.QueryServices;

public class ChefQueryService(IChefRepository chefRepository) 
    : IChefQueryService
{
    public async Task<IEnumerable<Chef>> Handle(GetAllChefsQuery query)
    {
        return await chefRepository.ListAsync();
    }

    public async Task<Chef?> Handle(GetChefByIdQuery query)
    {
        return await chefRepository.FindByIdAsync(query.Id);
    }
}