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

        public IActionResult Index()
        {
            var recipes = _context.Recipes.Include(x => x.Category).ToList();
            return View(recipes);
        }
    }
}
