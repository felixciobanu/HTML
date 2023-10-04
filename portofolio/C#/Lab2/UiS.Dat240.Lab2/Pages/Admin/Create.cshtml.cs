using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UiS.Dat240.Lab2;

namespace UiS.Dat240.Lab2.Pages_Admin
{
    public class CreateModel : PageModel
    {
        private readonly IFoodItemValidator _itemValidator;
        private readonly IFoodItemProvider _foodItemProvider;
        public string[]? errors;

        public CreateModel(IFoodItemValidator validator, IFoodItemProvider foodItemProvider)
        {
            _itemValidator = validator;
            _foodItemProvider = foodItemProvider;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public FoodItem FoodItem { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            errors = _itemValidator.IsValid(FoodItem);

            if (!ModelState.IsValid || errors.Length != 0)
            {
                return Page();
            }

            await _foodItemProvider.AddFoodItem(FoodItem);

            return RedirectToPage("./Index");
        }
    }
}