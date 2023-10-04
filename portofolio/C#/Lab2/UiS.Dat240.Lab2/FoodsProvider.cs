using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab2;

public class FoodsProvider: IFoodItemProvider
{
    private readonly ShopContext _shopContext;
    
    public FoodsProvider(ShopContext shopContext){
        _shopContext = shopContext;
    }
    
    public async Task<FoodItem[]> GetItems(){
        return await _shopContext.FoodItem.ToArrayAsync();
    }
    
    public async Task AddFoodItem(FoodItem item){
        await _shopContext.FoodItem.AddAsync(item);
        await _shopContext.SaveChangesAsync();
    }
    
    public async Task<FoodItem> GetFoodItem(int id)
    {
        return await _shopContext.FoodItem.FindAsync(id);
    }

    public async Task RemoveFoodItem(int id){
        var item = await _shopContext.FoodItem.FindAsync(id);
        if (item == null)
            return;
        _shopContext.FoodItem.Remove(item);
        await _shopContext.SaveChangesAsync();
    }
    
    public async Task UpdateFoodItem(int id, FoodItem item){
        var oldItem = await _shopContext.FoodItem.FirstOrDefaultAsync(item => item.Id == id);
        if(oldItem != null){
            oldItem.Name = item.Name;
            oldItem.Description = item.Description;
            oldItem.Price = item.Price;
            oldItem.CookTime = item.CookTime;
        }
        await _shopContext.SaveChangesAsync();
        
    }
}