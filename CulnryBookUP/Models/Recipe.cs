using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulnryBookUP.Models
{
    public class Recipe
    {
        [Key] public int IdRecipe { get; set; }
        [Required] public string RecipeName { get; set; }
        [Required] public string RecipeDescr { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("CategoryID")] public int? CategoryID { get; set; }
        
        [Required] public int CookingTime { get; set; }
        public virtual Image Image { get; set; }
        [ForeignKey("ImageID")]public int? ImageID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("IdUser")] public int? IdUser { get; set; }


        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
        public virtual ICollection<CookingStep> CookingSteps { get; set; }
        public Recipe() { }

        public Recipe(string recipeName, string recipeDescr, int? categoryID, int cookingTime, int userId)
        {
            RecipeName = recipeName;
            RecipeDescr = recipeDescr;
            CategoryID = categoryID;
            CookingTime = cookingTime;
            IdUser = userId;
        }
    }
}
