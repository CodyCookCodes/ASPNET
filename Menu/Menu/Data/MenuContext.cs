using Microsoft.EntityFrameworkCore;
using Menu.Models;


namespace Menu.Data
{
    public class MenuContext: DbContext
    {
        public MenuContext( DbContextOptions<MenuContext> options ) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientID
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientID);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name= "Margheritta", Price= 199.99, ImageUrl= "https://ca.ooni.com/cdn/shop/articles/20220211142645-margherita-9920.jpg?crop=center&height=800&v=1661341987&width=800" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Dish { Id = 1, Name = "Tomato Sauce"},
                new Dish { Id = 2, Name = "Mozzarella" }
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                   new DishIngredient { DishId = 1, IngredientID = 1 },
                   new DishIngredient { DishId = 1, IngredientID = 2 }
                    );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> dishIngredients { get; set; }
    }
}
