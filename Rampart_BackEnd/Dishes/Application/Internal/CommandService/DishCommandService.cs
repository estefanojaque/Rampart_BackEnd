﻿using Rampart_BackEnd.Dishes.Domain.Model.Aggregates;
using Rampart_BackEnd.Dishes.Domain.Model.Commands;
using Rampart_BackEnd.Dishes.Domain.Repositories;
using Rampart_BackEnd.Dishes.Domain.services;
using Rampart_BackEnd.Shared.Domain.Repositories;

namespace Rampart_BackEnd.Dishes.Application.Internal.CommandService;

public class DishCommandService(IDishRepository dishRepository, IUnitOfWork unitOfWork)
    : IDishCommandService
{
    public async Task<Dish?> Handle(CreateDishCommand command)
    {
        if(await dishRepository.ExistsByNameOfDishAndChefIdAsync(command.NameOfDish,command.ChefId))
            throw new Exception("Chef Id with the same name of dish already exists");
        var dish = new Dish(command);
        try
        {
            await dishRepository.AddSync(dish);
            await unitOfWork.CompleteAsync();
            return dish;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Dish?> Handle(UpdateDishCommand command)
    {
        var dish = await dishRepository.FindByIdAsync(command.Id);
        if (dish == null) return null;

        dish.ChefId = command.ChefId;
        dish.NameOfDish = command.NameOfDish;
        dish.Ingredients = command.Ingredients;
        dish.PreparationSteps = command.PreparationSteps;
        dish.Favorite = command.Favorite;

        try
        {
            dishRepository.Update(dish);
            await unitOfWork.CompleteAsync();
            return dish;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> DeleteDishCommand(int id)
    {
        var dish = await dishRepository.FindByIdAsync(id);
        if (dish == null) return false;

        try
        {
            dishRepository.Remove(dish);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}