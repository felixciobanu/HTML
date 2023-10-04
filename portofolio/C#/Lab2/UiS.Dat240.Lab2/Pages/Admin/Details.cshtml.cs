using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UiS.Dat240.Lab2;

namespace UiS.Dat240.Lab2.Pages_Admin
{
    public class DetailsModel : PageModel
    {
        private readonly ShopContext _context;
        private readonly IFoodItemValidator _itemValidator;
        private readonly IFoodItemProvider _foodItemProvider;

        public DetailsModel(ShopContext context, IFoodItemValidator validator, IFoodItemProvider foodItemProvider)
        {
            _context = context;
            _itemValidator = validator;
            _foodItemProvider = foodItemProvider;
        }

      public FoodItem FoodItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FoodItem == null)
            {
                return NotFound();
            }

            var fooditem = await _context.FoodItem.FirstOrDefaultAsync(m => m.Id == id);
            if (fooditem == null)
            {
                return NotFound();
            }
            else
            {
                await _foodItemProvider.GetFoodItem(fooditem.Id);
                FoodItem = fooditem;
            }
            return Page();
        }
    }
}
