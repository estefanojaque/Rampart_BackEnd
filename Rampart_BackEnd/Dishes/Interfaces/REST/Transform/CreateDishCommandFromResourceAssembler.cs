using Rampart_BackEnd.Dishes.Domain.Model.Commands;
using Rampart_BackEnd.Dishes.Interfaces.REST.Resources;

namespace Rampart_BackEnd.Dishes.Interfaces.REST.Transform;

public class CreateDishCommandFromResourceAssembler
{
    public static CreateDishCommand ToCommandFromResource(CreateDishResource resource)
    {
        return new CreateDishCommand(
            resource.ChefId,
            resource.NameOfDish,
            resource.Ingredients,
            resource.PreparationSteps
        );
    }
}