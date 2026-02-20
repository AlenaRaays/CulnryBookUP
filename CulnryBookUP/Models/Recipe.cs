using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulnryBookUP.Models
{
    public class Recipe
    {
        [Key] public int IdRecipe { get; set; }
        [Required] public string RecipeName { get; set; }
        [Required] public string RecipeDescr { get; set; }
        [Required, ForeignKey("CategoryID")] public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Required] public int CookingTime { get; set; }


    }
}
