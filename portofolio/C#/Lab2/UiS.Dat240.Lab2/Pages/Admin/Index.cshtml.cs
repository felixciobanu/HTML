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
    public class AdminModel : PageModel
    {
        private readonly IFoodItemProvider _foodItemProvider;

        public AdminModel(IFoodItemProvider foodItemProvider)
        {
            _foodItemProvider = foodItemProvider;
        }

        public IList<FoodItem> FoodItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FoodItem = await _foodItemProvider.GetItems();
        }
    }
}
