using CulnryBookUP.Data;
using CulnryBookUP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CulnryBookUP.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string categoryId)
        {
            ViewBag.CurrentCategory = categoryId;
            ViewBag.Categories = _context.Categories.ToList();

            var recipes = _context.Recipes.Include(x => x.Category).AsQueryable();

            if (!string.IsNullOrEmpty(categoryId) && categoryId != "all")
            {
                int id = int.Parse(categoryId);
                recipes = recipes.Where(r => r.CategoryID == id);
            }

            var userRole = HttpContext.Session.GetInt32("UserRole");
            ViewBag.loginedID = userRole ?? 0;

            return View(recipes.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> RecipeDetails(int id)
        {
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
