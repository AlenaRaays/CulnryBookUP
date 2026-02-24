using System.ComponentModel.DataAnnotations;
namespace CulnryBookUP.Models

{
    public class Ingredients
    {
        [Key] public int IngredientID { get; set; }
        [Required] public string IngredientName { get; set; }
        [Required] public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }

        public Ingredients() { }
        public Ingredients(string name)
        {
            IngredientName = name;
        }
    }
}
