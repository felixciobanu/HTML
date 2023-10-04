using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UiS.Dat240.Lab2;

namespace UiS.Dat240.Lab2.Pages_Admin
{
    public class EditModel : PageModel
    {
        private readonly ShopContext _context;
        private readonly IFoodItemValidator _itemValidator;
        public string[]? errors;
        private readonly IFoodItemProvider _foodItemProvider;

        public EditModel(ShopContext context, IFoodItemValidator validator, IFoodItemProvider foodItemProvider)
        {
            _itemValidator = validator;
            _foodItemProvider = foodItemProvider;
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            FoodItem = await _foodItemProvider.GetFoodItem(id);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _foodItemProvider.UpdateFoodItem(FoodItem.Id, FoodItem);
            return RedirectToPage("./Index");
        }
    }
}
