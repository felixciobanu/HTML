using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab2.Pages;

public class IndexModel : PageModel
{
    // private readonly ILogger<IndexModel> _logger;
    private readonly ShopContext _context;
    // public IndexModel(ILogger<IndexModel> logger)
    // {
    //     _logger = logger;
    // }

    public IndexModel(ShopContext context)
    {
        _context = context;
    }
    
    public IList<FoodItem> FoodItem { get;set; } = default!;
    
    public async Task OnGetAsync()
    {
        if (_context.FoodItem != null)
        {
            FoodItem = await _context.FoodItem.ToListAsync();
        }
    }
}
