namespace Rampart_BackEnd.Dishes.Domain.Model.Commands;
public record CreateDishCommand(int ChefId,string NameOfDish,List<string> Ingredients,List<string> PreparationSteps,bool Favorite = false);