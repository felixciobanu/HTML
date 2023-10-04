namespace UiS.Dat240.Lab2;

public interface IFoodItemValidator
{
    string[] IsValid(FoodItem foodItem);
}

public class FoodValidator : IFoodItemValidator{
    public string[] IsValid(FoodItem foodItem){

        var errors = new List<string>();

        if(string.IsNullOrEmpty(foodItem.Name))
            errors.Add("Please fill in name");

        if(foodItem.Price <= 0)
            errors.Add("Price must be greater than 0");
        
        if(string.IsNullOrEmpty(foodItem.Description))
            errors.Add("Please set a description");
  
        
        return errors.ToArray();
    }
}
