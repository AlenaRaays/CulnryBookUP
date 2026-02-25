using CulnryBookUP.Data;
using CulnryBookUP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CulnryBookUP.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string categoryId, string searchQuery, string sortBy)
        {
            ViewBag.CurrentCategory = categoryId;
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.SortedBy = sortBy;

            var recipes = _context.Recipes.Include(x => x.Category).AsQueryable();

            if (!string.IsNullOrEmpty(categoryId) && categoryId != "all")
            {
                int id = int.Parse(categoryId);
                recipes = recipes.Where(r => r.CategoryID == id);
            }

            if (!string.IsNullOrEmpty(searchQuery)) 
            {
                recipes = recipes.Where(x => x.RecipeName.StartsWith(searchQuery) || x.RecipeName.Contains(searchQuery));
            }

            if (!string.IsNullOrEmpty(sortBy) && sortBy == "asc")
            {
                recipes = recipes.OrderBy(x => x.RecipeName);
            }
            else if (!string.IsNullOrEmpty(sortBy) && sortBy == "desc")
            {
                recipes = recipes.OrderByDescending(x => x.RecipeName);
            }


                var userRole = HttpContext.Session.GetInt32("UserRole");
            ViewBag.loginedID = userRole ?? 1;

            bool isLoggined = HttpContext.Session.GetInt32("UserID") != null;
            ViewBag.Logined = isLoggined;

            return View(recipes.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> RecipeDetails(int id)
        {
            var userRole = HttpContext.Session.GetInt32("UserRole");
            ViewBag.loginedID = userRole ?? 1;

            var recipeDetails = await _context.Recipes
                .Include(x => x.Category)
                .Include(x => x.CookingSteps)
                .Include(x => x.Image)
                .Include(x => x.RecipeIngredients)
                    .ThenInclude(x => x.Ingredients)
                .FirstOrDefaultAsync(x => x.IdRecipe == id);

            if (recipeDetails == null)
            {
                return NotFound();
            }

            return View("RecipeDetails", recipeDetails);
        }
    }
}
