using Rampart_BackEnd.Chefs.Domain.Model.Aggregates;
using Rampart_BackEnd.Chefs.Interfaces.REST.Resource;

namespace Rampart_BackEnd.Chefs.Interfaces.REST.Transform;

public static class ChefResourceFromEntityAssembler
{
    public static ChefResource ToResourceFromEntity(Chef entity)
    {
        return new ChefResource(
            entity.Id,
            entity.Name,
            entity.Gender,
            entity.Rating,
            entity.IsFavorite
        );
    }
}
