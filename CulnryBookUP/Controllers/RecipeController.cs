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
        [HttpGet]
        public IActionResult AddRecipe()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddRecipe(AddRecipeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("<br>", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Content($"Ошибки валидации: <br>{errors}");
            }

            try
            {
                int currentUserId = 1; 

                // 2. Создаем рецепт
                var recipe = new Recipe
                {
                    RecipeName = model.RecipeName,
                    RecipeDescr = model.RecipeDescr,
                    CategoryID = model.CategoryID,
                    CookingTime = model.CookingTime,
                    IdUser = currentUserId,
                    ImageID = null 
                };

                _context.Recipes.Add(recipe);
                _context.SaveChanges(); 

                if (model.Ingredients != null && model.RecipeIngredients != null)
                {
                    for (int i = 0; i < model.Ingredients.Count; i++)
                    {
                        var ingItem = model.Ingredients[i];
                        if (string.IsNullOrEmpty(ingItem?.IngredientName)) continue;


                        var existingIngredient = _context.Ingredients
                            .FirstOrDefault(x => x.IngredientName == ingItem.IngredientName);

                        int ingredientId;

                        if (existingIngredient == null)
                        {
                            var newIngredient = new Ingredients
                            {
                                IngredientName = ingItem.IngredientName
                            };
                            _context.Ingredients.Add(newIngredient);
                            _context.SaveChanges();
                            ingredientId = newIngredient.IngredientID;
                        }
                        else
                        {
                            ingredientId = existingIngredient.IngredientID;
                        }


                        int quantity = 0;
                        if (i < model.RecipeIngredients.Count && model.RecipeIngredients[i] != null)
                        {
                            quantity = model.RecipeIngredients[i].Quantity;
                        }

                        var recipeIngredient = new RecipeIngredients
                        {
                            idRecipe = recipe.IdRecipe,
                            IntgredientID = ingredientId,
                            Quantity = quantity
                        };
                        _context.RecipeIngredients.Add(recipeIngredient);
                    }
                }

                if (model.CookingStep != null)
                {
                    int stepNumber = 1;
                    foreach (var step in model.CookingStep)
                    {
                        if (string.IsNullOrEmpty(step?.StepDescription)) continue;

                        var cookingStep = new CookingStep
                        {
                            idRecipe = recipe.IdRecipe,
                            StepNumber = stepNumber++,
                            StepDescription = step.StepDescription
                        };
                        _context.CookingSteps.Add(cookingStep);
                    }
                }

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    string imagePath = SaveImage(model.ImageFile, recipe.IdRecipe);

                    var image = new Image
                    {
                        IdRecipe = recipe.IdRecipe,
                        ImagePath = imagePath
                    };
                    _context.Images.Add(image);
                    _context.SaveChanges();

                    recipe.ImageID = image.ImageID;
                    _context.SaveChanges();

                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Recipe");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ошибка при сохранении: " + ex.Message);
                ViewBag.Categories = _context.Categories.ToList();
                return View(model);
            }
        }

        private string SaveImage(IFormFile file, int recipeId)
        {
            string fileName = file.FileName;

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"/pictures/{fileName}";
        }
    }
}
