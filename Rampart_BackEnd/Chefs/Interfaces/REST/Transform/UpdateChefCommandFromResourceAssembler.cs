using Rampart_BackEnd.Chefs.Domain.Model.Command;
using Rampart_BackEnd.Chefs.Interfaces.REST.Resource;

namespace Rampart_BackEnd.Chefs.Interfaces.REST.Transform;

public class UpdateChefCommandFromResourceAssembler
{
    public static UpdateChefCommand ToCommandFromResource(int id, UpdateChefResource resource)
    {
        return new UpdateChefCommand(
            id,
            resource.Name,
            resource.Gender,
            resource.Rating,
            resource.IsFavorite
        );
    }
}