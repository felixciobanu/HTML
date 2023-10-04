using Microsoft.EntityFrameworkCore;

namespace UiS.Dat240.Lab2;

// This class should inherit from the EntityFramework DbContext
public partial class ShopContextOld : DbContext
{
    public ShopContextOld(DbContextOptions<ShopContextOld> options)
        : base(options)
    {
        FoodItem = Set<FoodItem>();
    }

    // set a new foodItem
    public DbSet<FoodItem> FoodItem { get; set; }
    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Filename=FoodData.db");
        }
    }
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.Property(e => e.Id)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(true);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Price)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.CookTime)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);
        });
    }
}