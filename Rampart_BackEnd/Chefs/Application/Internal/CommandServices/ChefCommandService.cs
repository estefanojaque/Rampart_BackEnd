using Rampart_BackEnd.Chefs.Domain.Model.Aggregates;
using Rampart_BackEnd.Chefs.Domain.Model.Command;
using Rampart_BackEnd.Chefs.Domain.Repositories;
using Rampart_BackEnd.Chefs.Domain.Services;
using Rampart_BackEnd.Shared.Domain.Repositories;

namespace Rampart_BackEnd.Chefs.Application.Internal.CommandServices;

public class ChefCommandService(IChefRepository chefRepository, IUnitOfWork unitOfWork) 
    : IChefCommandService
{
    public async Task<Chef?> Handle(CreateChefCommand command)
    {
        if (await chefRepository.ExistsByTitleAsync(command.Name))
        {
            throw new Exception("Chef with the same name already exists");
        }
        var chef = new Chef(command);
        try
        {
            await chefRepository.AddSync(chef);
            await unitOfWork.CompleteAsync();
            return chef;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Chef?> Handle(UpdateChefCommand command)
    {
        var chef = await chefRepository.FindByIdAsync(command.Id);
        if (chef == null)
        {
            throw new Exception("Chef not found");
        }

        chef.Name = command.Name;
        chef.Gender = command.Gender;
        chef.Rating = command.Rating;
        chef.IsFavorite = command.IsFavorite;
        
        try
        {
            chefRepository.Update(chef);
            await unitOfWork.CompleteAsync();
            return chef;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteChefCommand(int id)
    {
        var chef = await chefRepository.FindByIdAsync(id);
        if (chef == null)
        {
            throw new Exception("Chef not found");
        }

        try
        {
            chefRepository.Remove(chef);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
