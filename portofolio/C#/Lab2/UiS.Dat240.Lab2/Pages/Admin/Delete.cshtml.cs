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
    public class DeleteModel : PageModel
    {
        private readonly ShopContext _context;
        private readonly IFoodItemProvider _foodItemProvider;

        public DeleteModel(ShopContext context, IFoodItemProvider foodItemProvider)
        {
            _context = context;
            _foodItemProvider = foodItemProvider;
        }

        [BindProperty]
      public FoodItem FoodItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
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
                FoodItem = fooditem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fooditem = await _context.FoodItem.FindAsync(id);

            if (fooditem != null)
            {
                FoodItem = fooditem;
                await _foodItemProvider.RemoveFoodItem(FoodItem.Id);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
