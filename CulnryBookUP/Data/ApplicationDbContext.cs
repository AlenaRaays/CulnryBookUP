using CulnryBookUP.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CulnryBookUP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public DbSet<CookingStep> CookingSteps { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.IdRole);
            modelBuilder.Entity<Recipe>()
                .HasOne(x => x.User)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x => x.IdUser);
            modelBuilder.Entity<Recipe>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x=>x.CategoryID);
            modelBuilder.Entity<Recipe>()
                .HasOne(x => x.Image)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x=>x.ImageID);
            modelBuilder.Entity<RecipeIngredients>()
                .HasOne(x => x.Ingredients)
                .WithMany(x => x.RecipeIngredients)
                .HasForeignKey(x => x.IntgredientID);
            modelBuilder.Entity<RecipeIngredients>()
                .HasOne(x => x.Recipe)
                .WithMany(x => x.RecipeIngredients)
                .HasForeignKey(x => x.idRecipe);
            modelBuilder.Entity<CookingStep>()
                .HasOne(x => x.Recipe)
                .WithMany(x => x.CookingSteps)
                .HasForeignKey(x => x.idRecipe);

        }
    } 
}
