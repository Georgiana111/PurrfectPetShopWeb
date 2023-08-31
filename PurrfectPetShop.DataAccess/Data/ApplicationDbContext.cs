using PurrfectPetShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PurrfectPetShop.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Dogs", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Cats", DisplayOrder = 2 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Labrador Retriever", ProductPrice = 100, CategoryId = 1, ImageUrl ="", Description="", Status="active"},
                new Product { Id = 2, Name = "British Shorthair", ProductPrice = 100, CategoryId = 1, ImageUrl = "", Description = "", Status = "active" }
                );
        }
    }
}
