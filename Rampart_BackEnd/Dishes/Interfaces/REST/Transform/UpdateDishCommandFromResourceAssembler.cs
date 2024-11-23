﻿using Rampart_BackEnd.Dishes.Domain.Model.Commands;
using Rampart_BackEnd.Dishes.Interfaces.REST.Resources;

namespace Rampart_BackEnd.Dishes.Interfaces.REST.Transform;

public class UpdateDishCommandFromResourceAssembler
{
    public static UpdateDishCommand ToCommandFromResource(UpdateDishResource resource)
    {
        return new UpdateDishCommand(
            resource.Id,
            resource.ChefId,
            resource.NameOfDish,
            resource.Ingredients,
            resource.PreparationSteps,
            resource.Favorite
        );
    }
}