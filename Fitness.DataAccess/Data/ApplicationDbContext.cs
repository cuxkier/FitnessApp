using Fitness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fitness.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<DietsCategory> DietsCategory { get; set; }
        public DbSet<Diet> Diet { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DietsCategory>().HasData(
                new DietsCategory { Id = 1, CategoryName = "Dieta Ketogeniczna", DisplayOrder = 1 },
                new DietsCategory { Id = 2, CategoryName = "Dieta Wysokobiałkowa", DisplayOrder = 2 },
                new DietsCategory { Id = 3, CategoryName = "Dieta Wegańska", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Diet>().HasData(
                new Diet { Id = 1, DietName = "Dieta 1500kcal", Description = "Dieta numer 1", Kcal = 1500, CategoryDietId = 1, ImageUrl = ""},
                new Diet { Id = 2, DietName = "Dieta 2000kcal", Description = "Dieta numer 2", Kcal = 1500, CategoryDietId = 2, ImageUrl = ""},
                new Diet { Id = 3, DietName = "Dieta 2500kcal", Description = "Dieta numer 3", Kcal = 1500, CategoryDietId = 1, ImageUrl = ""},
                new Diet { Id = 4, DietName = "Dieta 3000kcal", Description = "Dieta numer 3", Kcal = 1500, CategoryDietId = 3, ImageUrl = ""},
                new Diet { Id = 5, DietName = "Dieta 3500kcal", Description = "Dieta numer 3", Kcal = 1500, CategoryDietId = 2, ImageUrl = ""},
                new Diet { Id = 6, DietName = "Dieta 4000kcal", Description = "Dieta numer 3", Kcal = 1500, CategoryDietId = 3, ImageUrl = ""}
                );
        }
/*
        public DbSet<Bmi> Bmi { get; set; }
        protected override void BmiCalculator(Bmi bmi)
        {
            Bmi.Entity<Bmi>()
                );
        }
*/
    }
}
