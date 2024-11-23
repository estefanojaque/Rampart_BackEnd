using Rampart_BackEnd.Chefs.Domain.Model.Command;
using Rampart_BackEnd.Chefs.Interfaces.REST.Resource;

namespace Rampart_BackEnd.Chefs.Interfaces.REST.Transform;

public class CreateChefCommandFromResourceAssembler
{
    public static CreateChefCommand ToCommandFromResource(CreateChefResource resource)
    {
        return new CreateChefCommand(
            resource.Name,
            resource.Gender,
            resource.Rating,
            resource.IsFavorite
        );
    }
}
