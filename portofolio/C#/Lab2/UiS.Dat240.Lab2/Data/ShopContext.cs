using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UiS.Dat240.Lab2;

    public class ShopContext : DbContext
    {
        public ShopContext (DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<UiS.Dat240.Lab2.FoodItem> FoodItem { get; set; } = default!;
    }
